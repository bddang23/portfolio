;-------------------------------------------------
;- Assignment 4 - Binh Dang
;- 10/06/2021
;-------------------------------------------------

        .MODEL  small           ; Assume a "small" memory model
        .STACK 100h             ; Decalre a stack with 100h
        
        .DATA                   ; Declare Data
msg     DB  'The First Twenty Terms of the Fibonacci sequence:',0Ah,0Dh,'$'
array   DW      100d DUP (?)    ;100 byte array 

        .CODE                   ; Declare Code

start:  mov     ax,@DATA        ; Initialize Segment Registers
        mov     ds,ax
        
        lea     dx,msg
        call    display_msg     ;call procedure to display msg
        
        call    fibonacci       ;call a function         
       
        ;---end program             
exit:   mov     ax,4C00h        ; Call int21h to peacefully end the 
        int     21h             ;   program (DOS Terminate Program) 
        
                ;---display_msg display message
display_msg     PROC    near
                mov     ah, 09h
                int     21h
                ret                 ;return control to calling program
display_msg     ENDP
 
                ;fibonacci function will add number to array with the formula
                ;then print it out in reverse. 
fibonacci       PROC    near
                mov     cx, 18          ;loop counter
                mov     di, 0          ;initial array pointer
                mov     ax, 0000d        ;initial array value
                
                mov     array[00], 0d ;store the 1st and 2nd value
                mov     array[02], 01d          
repeat:         
                mov     ax,    array[di]
                mov     bx,    array[di+2]
                add     ax,    bx
                mov     array[di+4],  ax 
                inc     di
                inc     di
                loop    repeat
                
                add     di, 2 ;increase di by 2 to get to the last element
                
print_prog:     ;cmp     di,     0       
                mov     ax,    array[di]
                cmp     ax,     0   ;if ax is equal to 0, jump to print_zero to get the program to print the last 0
                je      print_zero
                call    extract_num 
                dec     di
                dec     di
                jmp    print_prog
                
print_zero:
                mov     dx,'0'                
                mov     ah,02h
                int     21h
                jmp     ret_main
                 
ret_main:
                ret
fibonacci       ENDP   
                
;when getting the number, the program will get the number
;start ectracting the number one by one from right to left then
;push it on the stack. Next, it will pop the stack and then 
;print the number out from left to right.             
extract_num     PROC    near
                
                mov     si,sp
                                
extraction:     cmp     ax, 0d
                je      print
                mov     dx, 00    ;clear dividens
                mov     cx, 10d   ;divisor 10
                div     cx        
                push    dx        ;after devided push the remainder to the stack
                jmp     extraction

print:
                cmp     si,sp
                je      line_break
                pop     dx
                mov     ah, 02h
                add     dx, 30h
                int     21h
                jmp     print
                
line_break:     mov     ah, 02h ;line break
                mov     dx, 10
                int     21h
               
return:
                ret
extract_num     ENDP
             
                
                

        END     start  