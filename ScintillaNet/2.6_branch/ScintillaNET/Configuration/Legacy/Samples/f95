module is_file
!  -------------
!  Copyright (C) 1995, 1997, Garnatz and Grovender, Inc.
!
!  Permission to distribute this software and its documentation within
!  your department or organization, is granted only under the terms
!  of our Software Licensing Agreement.  A fee must be paid for use
!  of this software.
!
!  For a copy of the Software Licensing Agreement write to:
!
!  Garnatz and Grovender, Inc.
!  5301 26th Avenue South
!  Minneapolis Minnesota USA 55417-1923
!  email: gginc@gginc.biz
!
!  This general terms of the Software Licensing Agreement provide for
!  distribution of this software under what is generally called a
!  "shareware" agreement.  If you are using this software, you are
!  requested to acquire a license to use it at one of the following
!  4 levels:
!
!  INDIVIDUAL USE:
!  level 0:  1 developer with source, and runtime on 1 computer    $95.00
!  MULTIPLE USE:
!  level 1:  1 developer, and up to 10 runtime copies             $250.00
!  level 2:  up to 10 developers, and up to 100 runtime copies    $850.00
!  level 3:  unlimited developers, and unlimited runtime copies  $7500.00
!
!  Upon payment and acceptance of the Software Licensing Agreement you
!  will be entitled to many benefits, including 1) updates and bugfixes
!  as needed, 2) complete documentation, 3) additional utility programs to
!  inquire into the status of files and repair damaged files, 4) access to
!  fee-based consulting and other services.
!
!  This software is provided as is and Garnatz and Grovender, Inc. disclaims
!  all warranties with regard to this software, including all implied warranties
!  of merchantability and fitness for a particular purpose.  In no event
!  shall Garnatz and Grovender, Inc. be liable for any special, indirect or
!  consequential damages or any damages whatsoever resulting from loss of
!  use, data or profits, whether in an action of contract, negligence or
!  other tortious action, arising out of or in connection with the use or
!  performance of this software.
!  -------------
      implicit none
!  isf public functions:
      public :: is_file_create
      public :: is_file_open
      public :: is_file_close
      public :: is_get_record
      public :: is_put_record
      public :: is_replace_record
      public :: is_delete_record
      public :: is_pos_begin
      public :: is_pos_eof
      public :: is_get_next_record
      public :: is_get_prev_record
!  isf private functions:
      private :: ixclean
      private :: delrec
      private :: putrec
      private :: split_block
      private :: findrec
      private :: next_rec
      private :: prev_rec
      private :: ext_err
      private :: find_unit
!  pk_isidx functions:
      private :: pk_file_create_isidx
      private :: pk_file_close_isidx
      private :: pk_get_record_isidx
      private :: pk_put_record_isidx
      private :: pk_delete_record_isidx 
      private :: pk_file_open_isidx
      private :: pk_file_rdhead_isidx
      private :: pk_file_wthead_isidx
      private :: pk_new_record_isidx
      private :: pk_new_rec_num_isidx 
!  pk_isdata functions:
      private :: pk_file_create_isdata
      private :: pk_file_close_isdata
      private :: pk_get_record_isdata
      private :: pk_put_record_isdata
      private :: pk_delete_record_isdata 
      private :: pk_file_open_isdata
      private :: pk_file_rdhead_isdata
      private :: pk_file_wthead_isdata
      private :: pk_new_record_isdata
      private :: pk_new_rec_num_isdata 
!
! Customize this file by entering your key(2x) and data fields below.
!
      type, public :: data_record_type_isdata
         character (len=8)                  :: key       ! YOUR KEY GOES HERE
         character (len=120)                :: data      ! YOUR DATA GOES HERE
      end type data_record_type_isdata
!
      integer, parameter, private :: maxitbl = 50    ! block size on index file
!
      type, public :: data_record_type_isidx
         character(len=8), dimension(maxitbl) :: key   !YOUR KEY HERE TOO
         integer,          dimension(maxitbl) :: iindex
         integer                              :: ngood
         character(len=1)                     :: level
      end type data_record_type_isidx
!
      type, public :: ixtree
         type (ixtree), pointer                 :: next
         type (ixtree), pointer                 :: prev
         type (data_record_type_isidx), pointer :: ixrec
         integer                                :: ix_rno
         integer                                :: cur_pos
      end type ixtree
!
      type, public :: is_block_defn
         type (pk_block_defn_isdata), pointer :: pk_block
         type (pk_block_defn_isidx),  pointer :: isidx_block
         type (data_record_type_isidx)        :: master
         type (ixtree)                        :: head
         type (ixtree), pointer               :: ixhead
         type (ixtree), pointer               :: ixptr
         logical                              :: found
      end type is_block_defn
!
      logical, private, parameter :: clean    = .true.
      logical, private, parameter :: is_debug = .false.
!
!  Two copies of the "pkf" file data types follow: 1) _isidx 2) _isdata
!
      type, private:: pk_record_isidx
         integer :: v_d_flag
         type (data_record_type_isidx) :: dat
      end type pk_record_isidx
!
      type, public :: pk_block_defn_isidx
         character (len=128) :: name
         character (len=8) :: v_name
         integer :: v_num
         character (len=48) :: copyrt
         integer :: num_recs
         integer :: del_ptr
         integer :: rec_len
         integer :: num_indx
         integer :: rsv3
         integer :: rsv2
         integer :: rsv1
         logical :: writable
         integer :: unit
         integer :: hdr_len
         integer :: first_loc
      end type pk_block_defn_isidx
!
      type (pk_record_isidx), private :: pk_record_temp_isidx
      type (pk_block_defn_isidx), pointer, private :: pk_block_isidx
!
      type, private:: pk_record_isdata
         integer :: v_d_flag
         type (data_record_type_isdata) :: dat
      end type pk_record_isdata
!
      type, public :: pk_block_defn_isdata
         character (len=128) :: name
         character (len=8) :: v_name
         integer :: v_num
         character (len=48) :: copyrt
         integer :: num_recs
         integer :: del_ptr
         integer :: rec_len
         integer :: num_indx
         integer :: rsv3
         integer :: rsv2
         integer :: rsv1
         logical :: writable
         integer :: unit
         integer :: hdr_len
         integer :: first_loc
      end type pk_block_defn_isdata
!
      type (pk_record_isdata), private :: pk_record_temp_isdata
      type (pk_block_defn_isdata), pointer, private :: pk_block_isdata
!
      integer, public, parameter :: PKERR_ILLREC = - 11
      integer, public, parameter :: PKERR_FILE = - 12
      integer, public, parameter :: PKERR_MEM = - 13
      integer, public, parameter :: PKERR_NOFILE = - 14
      !logical, private, parameter :: INDEX_FILE_SEPARATE = .false.  
      logical, private, parameter :: INDEX_FILE_SEPARATE = .true.  
!           .false. optional on some systems, like Cray and F compilers
!                   allows header to be at the beginning of the data file
!           .true.  required on some systems, like elf90 compiler
!                   requires header to be on a separate file
!
      integer, private :: last_rno_isdata
      integer, private :: last_rno_isidx
      integer, save, private :: extended_error
!
!
contains
! ------------------------------------------------
!     public functions and subroutines
! ------------------------------------------------
      subroutine is_file_create (fname, unit1, unit2, err)
         character (len=*), intent (in) :: fname
         integer, intent (in), optional :: unit1
         integer, intent (in), optional :: unit2
         integer, intent (out), optional :: err
         integer :: ijerr, ierr, jerr, irec, unitu

         type (pk_block_defn_isidx), pointer :: tpkblk
         type (data_record_type_isidx) :: master
!
         ijerr = 0
         if (present(unit1)) then
            unitu = unit1
         else
            call find_unit(unitu)
         end if
         call pk_file_create_isdata (fname, unit=unitu, err=ierr)
          ! write(unit=*, fmt=*) " dat file created ", ierr, unitu
         if (present(unit2)) then
            unitu = unit2
         else
            call find_unit(unitu)
         end if
         call pk_file_create_isidx (fname, unit=unitu, err=jerr)
          ! write(unit=*, fmt=*) " idx file created ", jerr, unitu
         ijerr = abs (ierr) + abs (jerr)
         if (ijerr == 0) then
            !tpkblk => pk_file_open_isidx (fname, unit=unitu, err=ierr)
            ! write(unit=*,fmt=*) " IS open master index  - 1"
            call pk_file_open_isidx (tpkblk, fname, unit=unitu)
            ! write(unit=*,fmt=*) " IS open master index  - 2"
            ierr = extended_error
            master%level = "B"
            master%ngood = 0
            if (clean) then
               master%iindex = 0 ! initialize - not really needed
               master%key = " " ! initialize - not really needed
            end if
            !irec = pk_new_record_isidx (tpkblk, master, jerr)
            call pk_new_record_isidx (tpkblk, master, irec)
            ! write(unit=*,fmt=*) " IS write master index ",irec
            if (irec /= 1) then
               ijerr = ijerr + 100
            end if
            ijerr = ijerr + abs (ierr) + abs (jerr)
            call pk_file_close_isidx (tpkblk, ierr)
            ! write(unit=*,fmt=*) " IS close master index ", ierr, ijerr
            ijerr = ijerr + abs (ierr)
         end if
         if( present (err)) then
            err = ijerr
         end if
          ! write(unit=*, fmt=*) " IS master created ", ijerr
         return
      end subroutine is_file_create
! ----------------------------------------------------------
      subroutine is_file_open (is_block, fname, unit1, unit2, err)
      ! was function is_file_open (fname, unit1, unit2, err) result (is_block)
         type (is_block_defn), pointer :: is_block
         character (len=*), intent (in) :: fname
         integer, intent (in), optional :: unit1
         integer, intent (in), optional :: unit2
         integer, intent (out), optional :: err
!
         integer :: ijerr, ierr, jerr, unitu
!
         allocate(is_block, stat=ijerr)
         is_block%found = .false.
         if (present(unit1)) then
            unitu = unit1
         else
            call find_unit(unitu)
         end if
         !is_block%pk_block => &
         !       pk_file_open_isdata (fname, unit=unitu, err=ierr)
         call pk_file_open_isdata (is_block%pk_block, fname, unit=unitu)
         ierr = extended_error
         ! write(unit=*, fmt=*) " data file open ", ierr
!
         if (present(unit2)) then
            unitu = unit2
         else
            call find_unit(unitu)
         end if
         !is_block%isidx_block =>  &
         !        pk_file_open_isidx (fname, unit=unitu, err=jerr)
         call pk_file_open_isidx (is_block%isidx_block, fname, unit=unitu)
         jerr = extended_error
         ! write(unit=*, fmt=*) " index file open ", jerr
!
         ijerr =  ijerr + abs (ierr) + abs (jerr)
!
         is_block%head%ixrec => is_block%master
         is_block%ixhead => is_block%head
         is_block%ixptr => is_block%ixhead
         is_block%ixhead%ix_rno = 1
         is_block%found = .false.
         nullify (is_block%ixhead%prev)
         nullify (is_block%ixhead%next)
         if (ijerr == 0) then
            call pk_get_record_isidx (is_block%isidx_block,&
                is_block%ixhead%ix_rno, is_block%master, ierr)
            ijerr = ijerr + abs (ierr)
         end if
         if (ijerr /= 0) then
            if(associated(is_block%pk_block)) then
               call pk_file_close_isdata(is_block%pk_block)
            end if
            if(associated(is_block%isidx_block)) then
               call pk_file_close_isidx(is_block%isidx_block)
            end if
            deallocate(is_block)
         else
            call is_pos_begin (is_block, ierr)
         end if
         ! write(unit=*, fmt=*) " data file open  - exiting", ijerr
         if (present (err)) then
            err = ijerr
         end if
         return
      !end function is_file_open
      end subroutine is_file_open
! ----------------------------------------------------------
      subroutine is_get_record (is_block, is_key, data_record, err)
         type (is_block_defn), pointer :: is_block
         character (len=*), intent (in) :: is_key
         type (data_record_type_isdata), intent (out) :: data_record
         integer, intent (out), optional :: err
         integer :: ierr, irec
!
         if(.not. associated(is_block)) then
            ierr = -100
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         is_block%ixptr => is_block%ixhead
         call findrec (is_block, is_key, irec)
         if (irec == 0) then
            ierr = 1
            is_block%found = .false.
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         is_block%found = .true.
         call pk_get_record_isdata (is_block%pk_block, irec, data_record, ierr)
         if (present(err)) then
               err = ierr
         end if
         return
      end subroutine is_get_record
! ----------------------------------------------------------
      subroutine is_put_record (is_block, data_record, err)
         type (is_block_defn), pointer :: is_block
         type (data_record_type_isdata), intent (in) :: data_record
         integer, intent (out), optional :: err
         integer :: ierr, irec
!
         if(.not. associated(is_block)) then
            ierr = -100
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         ierr = 0
         is_block%ixptr => is_block%ixhead
         call findrec (is_block, data_record%key, irec)
         if (irec /= 0) then
            ierr = 1
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         !irec = pk_new_record_isdata (is_block%pk_block, data_record, ierr)
         call pk_new_record_isdata (is_block%pk_block, data_record, irec)
         ! write(unit=*,fmt=*)" put record - ready  ", irec
         call putrec (is_block, data_record%key, irec)
         if (present(err)) then
            err = ierr
         end if
         return
      end subroutine is_put_record
! ----------------------------------------------------------
      subroutine is_replace_record (is_block, data_record, err)
         type (is_block_defn), pointer :: is_block
         type (data_record_type_isdata), intent(in out) :: data_record
         integer, intent (out), optional :: err
         type (data_record_type_isdata) :: trec
         integer :: ierr, irec
!
         if(.not. associated(is_block)) then
            ierr = -100
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         is_block%ixptr => is_block%ixhead
         call findrec (is_block, data_record%key, irec)
         if (irec == 0) then
            ierr = 1
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         !print*," replace - found record to replace"
         call pk_get_record_isdata (is_block%pk_block, irec, trec, ierr)
         if (ierr /= 0) then
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         call pk_put_record_isdata (is_block%pk_block, irec, data_record, ierr)
         if (present(err)) then
            err = ierr
         end if
         is_block%found = .true.
         return
      end subroutine is_replace_record
! ----------------------------------------------------------
      subroutine is_delete_record (is_block, is_key, err)
         type (is_block_defn), pointer :: is_block
         character (len=*), intent (in) :: is_key
         integer, intent (out), optional :: err
         integer :: ierr, irec
!
         if(.not. associated(is_block)) then
            ierr = -100
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         ierr = 0
         is_block%ixptr => is_block%ixhead
         call findrec (is_block, is_key, irec)
         if (irec <= 0) then
            ierr = 1
            if (is_debug) then
                write(unit=*, fmt=*)  " del_rec error1 ", irec
            end if
            if (present(err)) then
               err = ierr
            end if
            return
         else
            call pk_delete_record_isdata (is_block%pk_block, irec, ierr)
            if (ierr /= 0) then
               if (present(err)) then
                  err = ierr
               end if
               if (is_debug) then
                    write(unit=*, fmt=*)  " del_rec error2 ", irec, ierr
               end if
               return
            end if
         end if
         !print*," delete - found record to delete"
         call delrec (is_block)
         if (present(err)) then
            err = ierr
         end if
! re-establish position for next sequential op.
         call findrec (is_block, is_key, irec)
         return
      end subroutine is_delete_record
! ----------------------------------------------------------
      subroutine is_file_close (is_block, err)
         type (is_block_defn), pointer :: is_block
         integer, intent (out), optional :: err
         integer :: ijerr, jerr, ierr, master_loc
!
         if(.not. associated(is_block)) then
            ierr = -100
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         is_block%ixptr => is_block%ixhead
         ierr = ixclean (is_block%ixptr%next)
         master_loc = is_block%ixhead%ix_rno
         !print*," close - write master at ",master_loc
         call pk_put_record_isidx (is_block%isidx_block, master_loc, &
               is_block%master, ierr)
         ijerr = abs (ierr)
         call pk_file_close_isdata (is_block%pk_block, ierr)
         call pk_file_close_isidx (is_block%isidx_block, jerr)
         ijerr = ijerr + abs (ierr) + abs (jerr)
         deallocate(is_block, stat=ierr)
         ijerr = ijerr + abs (ierr)
         if (present(err)) then
            err = ijerr
         end if
         return
!
      end subroutine is_file_close
! ----------------------------------------------------------
      subroutine is_pos_begin (is_block, err)
         type (is_block_defn), pointer :: is_block
         integer, intent (out), optional :: err
         type (data_record_type_isidx), pointer :: iptr
         integer :: ierr, it, it_tmp
!
         if(.not. associated(is_block)) then
            ierr = -100
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         ierr = 0
         is_block%ixptr => is_block%ixhead
         is_block%ixptr%cur_pos = 1
         iptr => is_block%ixptr%ixrec
         do !while (iptr%level /= "B")
            if (iptr%level == "B" ) then
               exit
            end if
            it = is_block%ixptr%ixrec%iindex (1)
            it_tmp = -99
            if (associated(is_block%ixptr%next)) then
               it_tmp = is_block%ixptr%next%ix_rno
            end if
            if ( .not. associated(is_block%ixptr%next) .or.  &
                   it_tmp /= it) then
               ! was -- & is_block%ixptr%next%ix_rno /= it) then
               ierr = ixclean (is_block%ixptr%next)
               allocate (is_block%ixptr%next, stat=ierr)
               is_block%ixptr%next%prev => is_block%ixptr
               nullify (is_block%ixptr%next%next)
               nullify (is_block%ixptr%next%ixrec)
               it = is_block%ixptr%ixrec%iindex (1)
               is_block%ixptr => is_block%ixptr%next
               is_block%ixptr%ix_rno = it
               allocate (is_block%ixptr%ixrec, stat=ierr)
               iptr => is_block%ixptr%ixrec
               call pk_get_record_isidx (is_block%isidx_block, it,&
                  is_block%ixptr%ixrec, ierr)
               if (ierr /= 0) then
                  if (present(err)) then
               err = ierr
            end if
                  return
               end if
            else
               is_block%ixptr => is_block%ixptr%next
            end if
            iptr => is_block%ixptr%ixrec
            is_block%ixptr%cur_pos = 1
         end do
         is_block%ixptr%cur_pos = 0
         is_block%found = .false.
         if (present(err)) then
            err = ierr
         end if
         return
      end subroutine is_pos_begin
! ----------------------------------------------------------
      subroutine is_pos_eof (is_block, err)
         type (is_block_defn), pointer :: is_block
         integer, intent (out), optional :: err
         type (data_record_type_isidx), pointer :: iptr
         integer :: ierr, it, it_tmp
!
         if(.not. associated(is_block)) then
            ierr = -100
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         ierr = 0
         is_block%ixptr => is_block%ixhead
         iptr => is_block%ixptr%ixrec
         is_block%ixptr%cur_pos = iptr%ngood
         do  !while (iptr%level /= "B")
            if ( iptr%level == "B" ) then
               exit
            end if
            it = iptr%iindex (iptr%ngood)
            it_tmp = -99
            if (associated(is_block%ixptr%next)) then
               it_tmp = is_block%ixptr%next%ix_rno
            end if
            if ( .not. associated(is_block%ixptr%next) .or.  &
                  it_tmp /= it) then
               ierr = ixclean (is_block%ixptr%next)
               allocate (is_block%ixptr%next, stat=ierr)
               is_block%ixptr%next%prev => is_block%ixptr
               nullify (is_block%ixptr%next%next)
               nullify (is_block%ixptr%next%ixrec)
               is_block%ixptr => is_block%ixptr%next
               is_block%ixptr%ix_rno = it
               allocate (is_block%ixptr%ixrec, stat=ierr)
               iptr => is_block%ixptr%ixrec
               call pk_get_record_isidx (is_block%isidx_block, it,&
                  is_block%ixptr%ixrec, ierr)
               it = is_block%ixptr%ixrec%iindex (iptr%ngood)
               if (ierr /= 0) then
                  if (present(err)) then
               err = ierr
            end if
                  return
               end if
            else
               is_block%ixptr => is_block%ixptr%next
            end if
            iptr => is_block%ixptr%ixrec
            is_block%ixptr%cur_pos = iptr%ngood
         end do
         is_block%ixptr%cur_pos = iptr%ngood + 1
         is_block%found = .false.
         if (present(err)) then
            err = ierr
          end if
         return
      end subroutine is_pos_eof
! ----------------------------------------------------------
      subroutine is_get_next_record (is_block, data_record, err)
         type (is_block_defn), pointer :: is_block
         type (data_record_type_isdata), intent (out) :: data_record
         integer, optional, intent (out) :: err
         integer :: irec
         integer :: ierr
!
         ierr = 0
         if(.not. associated(is_block)) then
            ierr = -100
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         !irec = next_rec (is_block)
         call next_rec (is_block, irec)
         !print*," call next_rec "
         if (irec <= 0) then
            ierr = -1
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         call pk_get_record_isdata (is_block%pk_block, irec, data_record, ierr)
         if (present(err)) then
            err = ierr
         end if
         return
      end subroutine is_get_next_record
! ----------------------------------------------------------
      subroutine is_get_prev_record (is_block, data_record, err)
         type (is_block_defn), pointer :: is_block
         type (data_record_type_isdata), intent (out) :: data_record
         integer, intent(out), optional :: err
         integer :: ierr, irec
!
         ierr = 0
         if(.not. associated(is_block)) then
            ierr = -100
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         !irec = prev_rec (is_block)
         call prev_rec (is_block, irec)
         !print*," call prev_rec "
         if (irec <= 0) then
            ierr = -1
            if (present(err)) then
               err = ierr
            end if
            return
         end if
         call pk_get_record_isdata (is_block%pk_block, irec, data_record, ierr)
         if (present(err)) then
            err = ierr
          end if
         return
      end subroutine is_get_prev_record
! ----------------------------------------------------------
!     private functions and subroutines
! ----------------------------------------------------------
      recursive subroutine findrec (is_block, is_key, irec)
         type (is_block_defn), pointer :: is_block
         character (len=*), intent (in) :: is_key
         integer, intent(out) :: irec
         type (data_record_type_isidx), pointer :: iptr
         integer :: err, is, ie, it, it_tmp
!
         iptr => is_block%ixptr%ixrec
         is = 1
         ie = iptr%ngood
         irec = 0
         is_block%found = .false.
         ! write(unit=*,fmt=*) " findrec - start is/ie ",is,ie
         if (ie < is) then
            if (is_debug) then
            ! write(unit=*,fmt=*) " findrec - not found early return "
            end if
            is_block%ixptr%cur_pos = 0
            return
         end if
!
         search : do
         it = (is+ie+1) / 2
         if (is < ie) then
            if (is_key == iptr%key(it)) then
               exit search
            else if (is_key > iptr%key(it)) then
               is = it
            else
               ie = it - 1
            end if
         else if (is == ie) then
            exit search
         else
            it = is
            exit search
         end if
         end do search 
!
         if (it > iptr%ngood) then
            it = iptr%ngood
         end if
         is_block%ixptr%cur_pos = it
         if (iptr%level == "B") then
            irec = iptr%iindex (it)
            if (is_key == iptr%key(it)) then
               is_block%found = .true.
               return
            else if(it == 1 .and. is_key < iptr%key(it)) then
!      key is before first value in block
                is_block%ixptr%cur_pos = 0
            end if
            irec = 0
            !print*," findrec - not found return "
            return
         end if
!
         ! write(unit=*,fmt=*)" findrec - long index chain "
         it = iptr%iindex (it)
         it_tmp = -99
         if (associated(is_block%ixptr%next)) then
             it_tmp = is_block%ixptr%next%ix_rno
         end if
         if (associated(is_block%ixptr%next) .and. it_tmp == it) then
            is_block%ixptr => is_block%ixptr%next
         else
            err = ixclean (is_block%ixptr%next)
            allocate (is_block%ixptr%next, stat=err)
            nullify (is_block%ixptr%next%next)
            is_block%ixptr%next%prev => is_block%ixptr
            is_block%ixptr => is_block%ixptr%next
            allocate (is_block%ixptr%ixrec, stat=err)
            is_block%ixptr%ix_rno = it
            ! write(unit=*,fmt=*)" findrec - get isidx block ", it
            call pk_get_record_isidx (is_block%isidx_block, it,  &
                  is_block%ixptr%ixrec, err)
            iptr => is_block%ixptr%ixrec
            if (err /= 0) then
               return
            end if
         end if
         ! write(unit=*,fmt=*) " findrec  recurse,is_key ", is_key
         call findrec (is_block, is_key, irec)
         ! write(unit=*,fmt=*) " findrec  return - it ", irec
         return
      end subroutine findrec
! ----------------------------------------------------------
      subroutine delrec (is_block)
         type (is_block_defn), pointer :: is_block
         integer :: it, itn, ng
!
         !print*," delrec called "
         ng = is_block%ixptr%ixrec%ngood
         it = is_block%ixptr%cur_pos
         if (ng > 1) then
            if (it /= ng) then
               is_block%ixptr%ixrec%iindex (it:ng-1) =  &
                      is_block%ixptr%ixrec%iindex (it+1:ng)
               is_block%ixptr%ixrec%key (it:ng-1) =  &
                      is_block%ixptr%ixrec%key (it+1:ng)
            end if
         end if
         if (clean) then
            is_block%ixptr%ixrec%iindex (ng) = 0
            is_block%ixptr%ixrec%key (ng) = " "
         end if
         is_block%ixptr%ixrec%ngood = ng - 1
         ng = ng - 1
         call pk_put_record_isidx (is_block%isidx_block, &
                  is_block%ixptr%ix_rno, is_block%ixptr%ixrec)
         if ( .not. associated(is_block%ixptr%prev)) then
             return
         end if
! if empty node
         if (ng == 0) then
            call pk_delete_record_isidx (is_block%isidx_block, &
                  is_block%ixptr%ix_rno)
            is_block%ixptr => is_block%ixptr%prev
            ng = is_block%ixptr%ixrec%ngood
            it = is_block%ixptr%cur_pos
            if (is_debug) then
               write(unit=*,fmt=*) " delrec empty node ", it, ng
            end if
            if (ng > 1) then
               is_block%ixptr%ixrec%iindex (it:ng-1) = &
                    is_block%ixptr%ixrec%iindex (it+1:ng)
               is_block%ixptr%ixrec%key (it:ng-1) = &
                    is_block%ixptr%ixrec%key (it+1:ng)
            end if
            if (clean) then
               is_block%ixptr%ixrec%iindex (ng) = 0
               is_block%ixptr%ixrec%key (ng) = " "
            end if
            is_block%ixptr%ixrec%ngood = ng - 1
            ng = ng - 1
  
