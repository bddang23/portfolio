
;-------------------------------------------------
;- Assignment 2 - Binh Dang
;- 09/20/2021
;-------------------------------------------------

        .MODEL  small           ; Assume a "small" memory model

        .DATA                   ; Declare Data
line1   db  '+----------------------------------------------------------------------------+',0Dh,0Ah,'$'
line2   db  '|                     STARK INDUSTRIES SYSTEM INTERFACE                      |+',0Dh,0Ah,'$'
line3   db  '+----------------------------------------------------------------------------+|',0Dh,0Ah,'$'   
line4   db  ' +----------------------------------------------------------------------------+',0Dh,0Ah,'$'
newline db  0Dh,0Ah,'$'
line5   db  '            1)	Estimate build time on suit Mark VIII',0Dh,0Ah,'$'
line6   db  '            2)	Show plans for new arc reactor',0Dh,0Ah,'$'
line7   db  '            3)	Auto-schedule Avengers team meeting',0Dh,0Ah,'$'
line8   db  "            4)	Modify Jarvis' AI personality",0Dh,0Ah,'$'
line9   db  '            5)	Develop drone prototype',0Dh,0Ah,'$'
line10  db  '      Enter Choice: -->',0Dh,0Ah,'$'
line11  db  '|      Any unauthorized access will result in big, big trouble for you!      |+',0Dh,0Ah,'$'



        .CODE                   ; Declare Code

stark:  mov     ax,@DATA        ; Initialize Segment Registers
        mov     ds,ax              
                     
        ;---clear the screen             
        mov ah, 06h
        mov bh, 07h
        mov cx, 0000h 
        mov dh, 24d
        mov dl, 79d
        int 10h
                
        ;---print the first line
        mov ah,09h
        lea dx,line1
        int 21h
        
        ;---print the second line
        mov ah,09h
        lea dx,line2
        int 21h
        
        ;---print the third line
        mov ah,09h
        lea dx,line3
        int 21h  
                
        ;---print the fourth line
        mov ah,09h
        lea dx,line4
        int 21h    
        
        ;---enter new line
        mov ah,09h
        lea dx, newline
        int 21h   
        
        ;---print the fifth line
        mov ah,09h
        lea dx,line5
        int 21h
        
        ;---enter new line
        mov ah,09h
        lea dx, newline
        int 21h
        
        ;---print the sixth line
        mov ah,09h
        lea dx,line6
        int 21h
        
        ;---enter new line
        mov ah,09h
        lea dx, newline
        int 21h
        
        ;---print the seventh line
        mov ah,09h
        lea dx,line7
        int 21h
        
        ;---enter new line
        mov ah,09h
        lea dx, newline
        int 21h
        
        ;---print the eighth line
        mov ah,09h
        lea dx,line8
        int 21h
        
        ;---enter new line
        mov ah,09h
        lea dx, newline
        int 21h

        
        ;---print the ninth line
        mov ah,09h
        lea dx,line9
        int 21h
        
        ;---enter new line
        mov ah,09h
        lea dx, newline
        int 21h        
                
        ;---enter new line
        mov ah,09h
        lea dx, newline
        int 21h
        
        ;---print the tenth line
        mov ah,09h
        lea dx,line10
        int 21h
        
        ;---enter new line
        mov ah,09h
        lea dx, newline
        int 21h
        
        ;---print the fourth line since it looks the same
        mov ah,09h
        lea dx,line4
        int 21h
        
        ;---print the third line since it looks the same
        mov ah,09h
        lea dx,line3
        int 21h
        
        ;---print the eleventh line
        mov ah,09h
        lea dx,line11
        int 21h
        
        ;---print the first line since it looks the same
        mov ah,09h
        lea dx,line1
        int 21h

        ;---set curser position
        mov ah,02h
        mov bh,00h
        mov dx,1018h ;row10, column 18 in hex
        int 10h
        
        ;set cursor type
        mov ah,01h
        mov cx,04h  ;make cursor appear 
        int 21h
               
        ;---end program             
exit:   mov     ax,4C00h        ; Call int21h to peacefully end the 
        int     21h             ;   program (DOS Terminate Program)
        END     stark
