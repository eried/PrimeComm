      program airport
C  -------------
      implicit integer(a-z)
      character*1 yn
      integer  ierr, jerr, i
      character*128 fname
      character*8 mrec_key
      character*120 mrec_data
C
      ierr = 0
C     open file
      call hk_file_open('airport', 21, 'write', nkey_hkf, ierr)
      print*,' after first open ', ierr
      if(ierr .ne. 0) then
         print*,' create file '
         ierr = 0
         jerr = 0
         call hk_file_create('airport',  21, 251, ierr)
         if(ierr .ne. 0)print*,' create error ',ierr
         call hk_file_open('airport',  21, 'write', nkey_hkf, jerr)
         if((ierr .ne. 0) .or. (jerr .ne. 0)) then
            print*,' can''t open or create file', jerr
            stop
          end if
      end if
C
      yn = '?'
1000  continue
      ierr = 0
      if( yn .eq. '?' ) then
        print *,'function: n= write-new, r= read, d= delete'
        print *,'function: q= quit'
        print *,'          R= read-from-file, D= delete-from-file'
      end if
      write(*,fmt='(a)') 'Command: '
      read *,yn
      if (yn .eq. 'q')  go to 1001
      if (yn .eq. 'R' ) then
        i = 0
        fname = ' '
        write(*,fmt='(a)') 'Filename: '
        read *,fname
        open(unit=1,file=fname,err=3)
 1      continue
          read(1,fmt='(a3,5x,a)', err=2, end=3) mrec_key, mrec_data
          call raicas(mrec_key)
          i = i + 1
          call hk_put_new_record (mrec_key, mrec_data, ierr)
          if(ierr .ne. 0) print*,' put error ', ierr, mrec_key
        go to 1
  2     continue
        print*,' put error ', ierr, mrec_key
  3     continue
        close(1)
        print*,i,' records read '
      else if (yn .eq. 'r') then
         print *, ' please type in key'
         read *, mrec_key
         call raicas(mrec_key)
         call hk_get_record(mrec_key, mrec_data, ierr)
           if(ierr .ne. 0) then
             print*,' Record not found'
           else
             print 101,' record = ', mrec_key, mrec_data
 101         format(a,a8,a)
           end if
       else if (yn .eq. 'n') then
         print *,' type in new record data '
         read *,mrec_key, mrec_data
         call raicas(mrec_key)
         call hk_put_new_record(mrec_key, mrec_data, ierr)
           if(ierr .ne. 0) print*,' write(new) error'
       else if (yn .eq. 'd') then
         print *, ' please type in key'
         read *, mrec_key
         call raicas(mrec_key)
         call hk_delete_record(mrec_key, ierr)
           if(ierr .ne. 0) then
             print*,' delete error:', mrec_key,' ',ierr
           end if
       else if (yn .eq. 'D') then
         i = 0
         fname = ' '
         write(*,fmt='(a)') 'Filename: '
         read *,fname
         open(unit=2,file=fname,err=22)
 21      continue
          read(2,fmt='(a3)',err=22,end=22) mrec_key
          call raicas(mrec_key)
          call hk_delete_record(mrec_key, ierr)
           if(ierr .ne. 0) then
             print*,' delete error ', mrec_key
           else
             i = i + 1
           end if
          go to 21
 22      continue
         print*,i,' records deleted'
         close(2)
       else
         print *,' unrecogized command ',yn
         yn = '?'
       end if

      go to 1000
1001  continue
 99   continue
      if(ierr .eq. 0) then
         print*,' closing '
         call hk_file_close(ierr)
      end if
        if(ierr .ne. 0) print*,' close error', ierr
C ------------------------------------------------
      end
      subroutine raicas (zstr)
      character*(*) zstr
C  Raise a string to upper case
      character*26 zlwc
      character*26 zupc
      parameter (zlwc='abcdefghijklmnopqrstuvwxyz')
c     parameter (zupc='ABCDEFGHIJKLMNOPQRSTUVWXYZ')
      integer trim_len
      zupc = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
C  
      lstr = trim_len (zstr)
      do 10 istr = 1, lstr
        irnk = index (zlwc, zstr (istr:istr))
        if (irnk .gt. 0) then
          zstr (istr:istr) = zupc (irnk:irnk)
        endif
  10  continue
      end

