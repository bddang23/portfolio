USE ap;
SELECT vendor_name, vendor_contact_last_name, vendor_contact_first_name
	FROM vendors
    ORDER BY vendor_contact_last_name, vendor_contact_first_name ASC;
    
SELECT CONCAT(vendor_contact_last_name, ", " , vendor_contact_first_name) AS full_name
	FROM vendors
    WHERE vendor_contact_last_name REGEXP '^[ABCE]'
    ORDER BY vendor_contact_last_name, vendor_contact_first_name ASC;

SELECT  invoice_due_date, invoice_total, invoice_total*10/100 AS '10%', invoice_total*1.1 AS 'Plus 10%'
	FROM invoices
    WHERE invoice_total >= 500 AND invoice_total <= 1000
    ORDER BY invoice_due_date DESC;
    
SELECT invoice_number, invoice_total, payment_total + credit_total AS 'payment_credit_total', invoice_total - payment_total - credit_total AS 'balance_due'
	FROM invoices
    WHERE invoice_total - payment_total - credit_total > 50
    ORDER BY invoice_total - payment_total - credit_total DESC
    LIMIT 5;
    
SELECT invoice_number, invoice_date, invoice_total-payment_total-credit_total AS 'balance_due', payment_date
	FROM invoices
    WHERE payment_date IS NULL;
    
SELECT DATE_FORMAT(CURRENT_DATE,'%m-%d-%Y') AS 'current_date';

SELECT 50000 AS 'starting_principal', 50000*6.5/100 AS 'interest', 50000 * 106.5/100 AS 'principal_plus_interest';