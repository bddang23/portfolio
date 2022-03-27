USE ap;
SELECT * from invoices;
SELECT * from vendors;
SELECT * from invoice_line_items;
SELECT * FROM general_ledger_accounts;

SELECT vendor_name, invoice_number, invoice_date, (invoice_total-payment_total-credit_total) AS balance_due
FROM vendors v JOIN invoices i
ON v.vendor_id = i.vendor_id
WHERE (invoice_total-payment_total-credit_total) > 200
ORDER BY balance_due;

SELECT v.vendor_id, v.vendor_name, CONCAT(v.vendor_contact_first_name," ", v.vendor_contact_last_name) AS contact_name
FROM vendors v JOIN vendors v1
ON v.vendor_contact_first_name = v1.vendor_contact_first_name 
AND v.vendor_id <> v1.vendor_id
ORDER BY v.vendor_contact_last_name;

SELECT g.account_number, account_description
FROM general_ledger_accounts g 
LEFT JOIN invoice_line_items i
ON g.account_number = i.account_number
WHERE i.account_number IS NULL;

SELECT vendor_name, "No Phone" AS vendor_phone
FROM vendors 
WHERE vendor_phone IS NULL
UNION
SELECT vendor_name, vendor_phone AS vendor_phone
FROM vendors
WHERE vendor_phone IS NOT NULL
ORDER BY vendor_name;

SELECT v.vendor_name, invoice_number, invoice_date, i.invoice_id, line_item_amount, line_item_description
FROM vendors v JOIN invoices i
ON v.vendor_id = i.vendor_id
JOIN invoice_line_items il 
ON i.invoice_id = il.invoice_id
ORDER BY invoice_id; 

CREATE TABLE new_terms(
	terms_id INT AUTO_INCREMENT PRIMARY KEY,
    terms_description varchar(255),
    terms_due_date INT);
INSERT INTO new_terms(terms_id, terms_description, terms_due_date)VALUE(6, "Net due 150 days", 150);
SELECT * FROM new_terms;
    
UPDATE new_terms 
SET terms_description = "Net Due In 180 Days" , terms_due_date = 180
WHERE terms_id=6;
SELECT * FROM new_terms;

DELETE FROM new_terms
WHERE terms_id=6;
SELECT * FROM new_terms;

INSERT INTO new_terms(terms_id) VALUE (5);
UPDATE new_terms
SET terms_description = "Net Due In 100 Days" , terms_due_date = 100
WHERE terms_id =5;
SELECT * FROM new_terms;

SELECT vendor_name, SUM(invoice_total) AS invoice_total
FROM vendors v JOIN invoices i
ON v.vendor_id = i.vendor_id
GROUP BY vendor_name;

-- SELECT i.vendor_id, i.account_description, MAX(total_invoice) AS total_invoice
-- FROM
(SELECT i.vendor_id, COUNT(i.vendor_id) AS total_invoice, g.account_description
FROM invoices i  JOIN vendors v
ON i.vendor_id = v.vendor_id
JOIN general_ledger_accounts g
ON v.default_account_number = g.account_number
GROUP BY vendor_id
ORDER BY total_invoice DESC); -- ) i;

SELECT tab.vendor_id, tab.account_description, MAX(total_invoice_amt) AS total_invoice
FROM(
SELECT i.vendor_id, SUM(invoice_total) AS total_invoice_amt, g.account_description
FROM invoices i  JOIN vendors v
ON i.vendor_id = v.vendor_id
JOIN general_ledger_accounts g
ON v.default_account_number = g.account_number
GROUP BY vendor_id
ORDER BY total_invoice_amt DESC) tab;

-- QUESTION 12
SELECT tab.vendor_name, tab.vendor_id, tab.account_number, tab.line_item_description,  COUNT(DISTINCT tab.account_number)
FROM (
SELECT vendor_id, account_number, ili.line_item_description
FROM invoices i
JOIN invoice_line_items ili
ON i.invoice_id = ili.invoice_id
UNION 
(SELECT vendor_name, vendor_id, default_account_number, vendor_name
FROM vendors)
ORDER BY vendor_id) tab
GROUP BY tab.vendor_id
HAVING COUNT(DISTINCT tab.account_number) > 1 ;

-- QUESTION 13
SELECT i.vendor_id, MAX(a.late_payment) AS number_of_late_payments
FROM invoices i JOIN (
SELECT vendor_id, COUNT(*) AS late_payment
FROM invoices 
WHERE payment_date - invoice_due_date > 0
GROUP BY vendor_id) a;

-- QUESTION 14
SELECT AVG(payment_total) AS avg_payment
FROM invoices
WHERE payment_total > 0;

SELECT i.invoice_id, i.payment_total, a.avg_payment
FROM invoices i 
JOIN ( SELECT invoice_id, AVG(payment_total) AS avg_payment
FROM invoices
HAVING SUM(payment_total)>0) a 
WHERE i.payment_total > a.avg_payment
ORDER BY a.avg_payment;


SELECT gen.account_number, account_description
FROM general_ledger_accounts gen 
WHERE NOT EXISTS(
	SELECT * FROM invoice_line_items inv
	WHERE gen.account_number = inv.account_number)
ORDER BY account_number;
