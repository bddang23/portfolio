;-------------------------------------------------
;- Assignment 3 - Binh Dang
;- 09/29/2021
;-------------------------------------------------

        .MODEL  small           ; Assume a "small" memory model
        .STACK 100h             ; Decalre a stack with 100h
        
        .DATA                   ; Declare Data
msg     DB  'Decimal 65535 = Binary  $' 

        .CODE                   ; Declare Code

start:  mov     ax,@DATA        ; Initialize Segment Registers
        mov     ds,ax 
        
        lea     dx,msg
        call    display_msg     ;call procedure to display msg
        
        mov     ax,65535d 
        call    display_bin     ;call procedure to display binary             
       
        ;---end program             
exit:   mov     ax,4C00h        ; Call int21h to peacefully end the 
        int     21h             ;   program (DOS Terminate Program)
                                  
        
        ;---display_msg display text message
display_msg     PROC    near
                mov     ah, 09h
                int     21h
                ret                 ;return control to calling program
display_msg     ENDP  

        ;---display_bin display binary number
        ;divide ax by 2 until the remainder reaching 0
        ;while doing that, add it to the stack
        ;after finished, pop and print out by add 30h to dx to print out ASCII character

display_bin     PROC    near
                
                cmp     ax, 00d ;if number is equal to 0, print out 0 and return
                                ;else jump to "normal" code segment
                jne     normal
                       
                mov     dx,'0'                
                mov     ah,02h
                int     21h
                jmp     ret_exit
                    
normal:                ;reserve register for the main program
                push    ax
                push    bx
                push    cx
                push    dx
                mov     si, sp ;compare if it is the end of the stack (number) or not
                
                              
change_bin:     
                cmp     ax, 01d
                jb      print
                mov     dx, 00    ;clear dividens
                mov     cx, 02d   ;divisor 2
                div     cx        
                push    dx        ;after devided push the remainder to the stack
                jmp     change_bin


print:          pop     dx
                add     dx,30h  ;Add 30h to print ASCII number        
                mov     ah,02h  ;print out binary number on screen  
                int     21h
                cmp     sp,si
                jb      print  
              
                ;reload to original register
                pop     dx
                pop     cx
                pop     bx
                pop     ax
                
ret_exit:        
                ret             ;return control to calling program

display_bin     ENDP     
                
        END     start  
        
;Is there a limit to the size of the integer numbers that you can print out in binary?  Why or why not?
;   - The limit of the size is 16-bit number since the register can only hold upto 4 bytes of number size
;   65535 which is 2^16-1. 

;If there is a limit, what would happen if you hit it?  Is there anything you could do about it?
;   - When hit the limit, the program will not woking since it is a 16-bit register.We can create 
;     an offset that keep the memory of the number.
   