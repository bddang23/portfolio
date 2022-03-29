;-------------------------------------------------
;- Assignment 5 - Binh Dang
;- 10/15/2021
;-------------------------------------------------               
                .MODEL  small
                .STACK  100h
                .DATA
 file_buf       DB      4*65 DUP (?)               ;buffer zone
 file_name      DB      'C:\Employee_Info.TXT',00h    ;ASCIIZ string

 INPUTSTRUCT    LABEL   BYTE
   MaxLen       DB      30
   ActLen       DB      00
   InputBuf     DB      30 DUP(?)
 
 handle1        DW      0
 ;-----------------------------------------------------
 ;--- err_chk routine related data
 ;-----------------------------------------------------
      cr        EQU     0Dh     ;carriage return
      lf        EQU     0Ah     ;line feed
      enter     DB      0Dh, 0Ah,'$';both lf and cr 
      enter1    DB      0Dh,0Ah ;lfand cr without $ sign
      
      errtbl    DW      0,err1,err2,err3,err4,err5,err6
                DW      5 DUP (0)
                DW      err12
      err1      DB      'Invalid function number',lf,cr,'$'
      err2      DB      'File not found',lf,cr,'$'
      err3      DB      'Path not found',lf,cr,'$'
      err4      DB      'Too many open files',lf,cr,'$'
      err5      DB      'Access denied',lf,cr,'$'
      err6      DB      'Invalid handle',lf,cr,'$'
      err12     DB      'Invalid access code',lf,cr,'$'
 
 ;-------------------------
 ;--message for input
    line1       DW       'Employee Name: $' 
    line2       DW       'Employee Employee Phone Number: $'
    line3       DW       'Employee Social Security Number: $'
    line4       DW       'Employee Date of Birth: $'
    msg         DW       lf,lf,cr,'The structure was successfully written to file C:\Employee_Info.TXT',lf,cr,'$'
    
;---------------------------
;--location for cursor
    array       DB      8d      DUP (?)  
      
      ;--- Write a macro routine for printing
print   MACRO   msg
        mov     ah,9h    
        lea     dx,msg   
        int     21h
        
        ;print lf and cr
        mov     ah,9h    
        lea     dx,enter   
        int     21h
ENDM

;--- Write a macro routine for moving the cursor
locate  MACRO   row,col
        mov     ah,2    ;BIOS cursor x,y coords
        mov     bh,0    ;page 0
        mov     dh,row  ;y-coord
        mov     dl,col  ;x-coord
        int     10h
ENDM

                .CODE
 start:
                mov     ax,@DATA
                mov     ds,ax

 ;--- Create and Open File

                mov     ah,3Ch          ;Create file
                mov     cx,00           ;"normal" attribute
                lea     dx,file_name    ;pointer to name of file
                int     21h
                                  
                call    err_chk         
                            `           
                mov     handle1,ax      

 ;--- Input the records to file

                ;print out message before get input
                print   line1  
                print   line2 
                print   line3
                print   line4
                
                ;make an array of cursor pointer 
                mov     array[00],   0d
                mov     array[01],   15d
                
                mov     array[02],   1d
                mov     array[03],   32d
                
                mov     array[04],   2d
                mov     array[05],   33d
                
                mov     array[06],   3d
                mov     array[07],   24d  
                 
                mov     cx,04           ;loop counter, 4 strings
                mov     di,00           ;array ponter
    repeatread:
                push    cx              ;save loop counter
                mov     si,cx           ;save the count of cx
                locate  array[di], array[di+1]
                  
 ;--- write message prompt to the file
 ;if cx is at 4 print the first line
 ;cx=3 print line 2 and so on
                mov     ch, 00
                mov     ah,40h         ;write to file
                mov     bx,handle1     ;file handle
                
                cmp     si,04
                je      prline1
                
                cmp     si,03
                je      prline2
                
                cmp     si,02
                je      prline3
                
                cmp     si,01
                je      prline4
                
prline1:        
                mov     cl,array[di+1]
                lea     dx, line1 ;content of the message prompt
                jmp     interupt 

prline2:        
                mov     cl,array[di+1]          ;actual bytes to write
                lea     dx, line2 ;content of the message prompt
                jmp     interupt

prline3:        mov     cl, array[di+1]         ;actual bytes to write
                lea     dx, line3 ;content of the message prompt
                jmp     interupt
                                
prline4:        
                mov     cl,array[di+1]          ;actual bytes to write
                lea     dx, line4 ;content of the message prompt
                                              
interupt:       int     21h
                call    err_chk         ;exit on error
                
 ;=---------------------              
                lea     dx,INPUTSTRUCT
                mov     ah,0ah          ;request input
                int     21h       
                
                mov     bh,00h           ;replace return char
                mov     bl,ActLen        ;with the a null since we
                mov     InputBuf[bx],00h ;have CR/LF at end of struct

 ;--- write data to file
                mov     cx,30          ;actual bytes to write
                mov     ah,40h          ;write to file           
                mov     bx,handle1      ;file handle
                lea     dx,INPUTSTRUCT+2
                                                
                int     21h
                
 ;--- write line break and carriage return to file
                mov     cx,2          ;actual bytes to write
                mov     ah,40h          ;write to file
                mov     bx,handle1      ;file handle
                lea     dx,enter1        ;line break and carriage return
                int     21h 
                
                call    err_chk         ;exit on error
                
                call    clear_buff      ;clear buffer
                
                pop     cx              ;restore repeat counter
                add     di,2            ;add two to di              
                loop    repeatread

 ;---
 ;- Close file
                mov     ah,3Eh          ;close file
                mov     bx,handle1      ;file handle
                int     21h
                call    err_chk         ;exit on error                           
                               
 ; print out message
                print msg
                
  ;--------------------------------
  ;read information back in from a file

                mov     ah,3Dh          ;open file
                mov     al,00b         ;read access
                lea     dx,file_name    ;address
                int     21h
                call    err_chk         ;exit on error
                mov     handle1,ax      ;save file handle

 ;--- Get length of file

                mov     ah,42h          ;move pointer

          ;---
          ;- Set an open file's location pointer at the offset
          ;- in CX:DX
  
                mov     al,02h          ;offset from end of file
                mov     bx,handle1      ;file handle
                xor     cx,cx           ;set cx = 0
                xor     dx,dx           ;set dx = 0
                int     21h             ;file length in DS:AX
                push    ax              ;AX = file length
                                        ;DX = 0 in this example
                call    err_chk

 ;--- Reset file pointer to beginning of file
                mov     ah,42h          ;move pointer
                mov     al,00h          ;set at start of file
                mov     bx,handle1      ;file handle
                xor     cx,cx           ;CX = 0
                xor     dx,dx           ;DX = 0
                int     21h
                call    err_chk

 ;--- Read file
                mov     ah,3Fh          ;read file
                mov     bx,handle1      ;file handle
                pop     cx              ;read bytes
                lea     dx,file_buf     ;address
                int     21h
                call    err_chk

                
 ;--- Display data in file buffer
                mov     ah,40h          ;write to device
                mov     bx,1            ;device = screen
                mov     cx,4*65         ;write 65 bytes including the message line
                lea     dx,file_buf     ;address
                int     21h

 ;--- Close file
                mov     ah,3Eh          ;close file
                mov     bx,handle1      ;file handle
                int     21h
                call    err_chk

 exit:
                mov     ax,4C00h
                int     21h

 ;-----------------------------------------------------
 ;--- err_chk routine

 err_chk        PROC    near
                jnc     exitproc        ;no error then exit procedure
                mov     bx,ax
                mov     ah,9            ;display string
                mov     dx,errtbl[bx]   ;message offset
                int     21h
                mov     ax,4C00h        ;terminate on error
                int     21h
    exitproc:   ret
 
 err_chk        ENDP 

                
 clear_buff     PROC    near
                mov     bh,00h       
                mov     bl,20    ;clear the last 20 bytes
                                 ;in the data buffer
    clear:      cmp     bl,00
                je      return
                mov     InputBuf[bx],00h 
                dec     bl
                jmp     clear
                     
    return:     ret                 
 clear_buff     ENDP

                END     start             
