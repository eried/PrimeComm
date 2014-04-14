Base 64 encode/decode

--------------------------------------------------------------------------------

  -- Base64 encode/decode & test driver.
  -- Copyright 2001 Tom Moran (tmoran@acm.org, PGP signed tmoran@bix.com),
  -- anyone may use for any purpose.

with Ada.Streams;
package Base64 is

  -- RFC 1521, MIME Base64 encode/decode
  -- Assumes Ada.Streams.Stream_Element is a byte.

  procedure Decode(Source  : in     String;
                   Target  :    out Ada.Streams.Stream_Element_Array;
                   Last    :    out Ada.Streams.Stream_Element_Offset);
  -- decode Source into Target(Target'first .. Last)
  -- Note: it may be appropriate to prescan Source for '=',
  -- indicating termination, or for illegitimate characters,
  -- indicating corruption, before calling Decode.

  procedure Encode(Source  : in     Ada.Streams.Stream_Element_Array;
                   Target  :    out String;
                   Last    :    out Natural);
  -- Target is filled in four character increments, except that
  -- a CR-LF pair is inserted after every 76 characters.
  -- Target'length must be at least:
  -- Output_Quad_Count: constant := (Source'length + 2) / 3;
  -- Output_Byte_Count: constant := 4 * Output_Quad_Count;
  -- Target'length = Output_Byte_Count + 2 * (Output_Byte_Count / 76)
  -- Constraint_Error will be raised if Target isn't long enough.

end Base64;

with Ada.Streams;
package body Base64 is

  subtype Six_Bits is Ada.Streams.Stream_Element range 0 .. 63;

  From_String: constant array (Character) of Six_Bits
    := ('A' => 0,'B' => 1,'C' => 2,'D' => 3,'E' => 4,'F' => 5,'G' => 6,
        'H' => 7,'I' => 8,'J' => 9,'K' =>10,'L' =>11,'M' =>12,'N' =>13,
        'O' =>14,'P' =>15,'Q' =>16,'R' =>17,'S' =>18,'T' =>19,'U' =>20,
        'V' =>21,'W' =>22,'X' =>23,'Y' =>24,'Z' =>25,'a' =>26,'b' =>27,
        'c' =>28,'d' =>29,'e' =>30,'f' =>31,'g' =>32,'h' =>33,'i' =>34,
        'j' =>35,'k' =>36,'l' =>37,'m' =>38,'n' =>39,'o' =>40,'p' =>41,
        'q' =>42,'r' =>43,'s' =>44,'t' =>45,'u' =>46,'v' =>47,'w' =>48,
        'x' =>49,'y' =>50,'z' =>51,'0' =>52,'1' =>53,'2' =>54,'3' =>55,
        '4' =>56,'5' =>57,'6' =>58,'7' =>59,'8' =>60,'9' =>61,'+' =>62,
        '/' =>63,
        others => 0);

  procedure Decode(Source  : in     String;
                   Target  :    out Ada.Streams.Stream_Element_Array;
                   Last    :    out Ada.Streams.Stream_Element_Offset) is
  -- decode Source into Target(Target'first .. Last)
  -- Note: it may be appropriate to prescan Source for '=',
  -- indicating termination, or for illegitimate characters,
  -- indicating corruption, before calling Decode.
    use type Ada.Streams.Stream_Element;
    use type Ada.Streams.Stream_Element_Offset;
    D       : Six_Bits;
    type Slots is mod 4;
    Slot    : Slots := 0;
  begin
    Last := Target'first - 1;
    for Si in Source'range loop
      D := From_String(Source(Si));
      if D /= 0 or else Source(Si) = 'A' then
        -- OK source
        case Slot is
          when 0 =>
            Last := Last + 1;
            Target(Last) := 4 * D;            -- dddddd00 ........ ........
          when 1 =>
            Target(Last) := Target(Last) + D / 16;
            exit when Last = Target'last
              and then (Si = Source'last or else Source(Si + 1) = '=')
              and then (D mod 16) = 0;
            Last := Last + 1;
            Target(Last) := (D mod 16) * 16;  -- dddddddd dddd0000 ........
          when 2 =>
            Target(Last) := Target(Last) + D / 4;
            exit when Last = Target'last
              and then (Si = Source'last or else Source(Si + 1) = '=')
              and then (D mod 4) = 0;
            Last := Last + 1;
            Target(Last) := (D mod 4) * 64;   -- dddddddd dddddddd dd000000
          when 3 =>
            Target(Last) := Target(Last) + D; -- dddddddd dddddddd dddddddd
        end case;
        Slot := Slot + 1;
      elsif Source(Si) = '=' then
        exit; -- terminator encountered
      end if; -- silently ignore whitespace, lf, garbage, ...
    end loop;
  end Decode;


  To_String: constant array (Six_Bits) of Character
    := "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

  procedure Encode(Source  : in     Ada.Streams.Stream_Element_Array;
                   Target  :    out String;
                   Last    :    out Natural) is
  -- Target is filled in four character increments, except that
  -- a CR-LF pair is inserted after every 76 characters.
  -- Target'length must be at least:
  -- Output_Quad_Count: constant := (Source'length + 2) / 3;
  -- Output_Byte_Count: constant := 4 * Output_Quad_Count;
  -- Target'length = Output_Byte_Count + 2 * (Output_Byte_Count / 76)
  -- Constraint_Error will be raised if Target isn't long enough.
    use type Ada.Streams.Stream_Element;
    use type Ada.Streams.Stream_Element_Offset;
    D       : Six_Bits;
    type Slots is mod 3;
    Slot    : Slots := 0;
    Output_Line_Length: Natural := 0;
  begin
    Last := Target'first - 1;
    for Si in Source'range loop
      case Slot is
        when 0 =>
          if Output_Line_Length = 76 then
            Last := Last + 2;
            Target(Last - 1) := Ascii.Cr;
            Target(Last) := Ascii.Lf;
            Output_Line_Length := 0;
          end if;
          Output_Line_Length := Output_Line_Length + 4;
          Last := Last + 4;
          Target(Last - 3) := To_String(Source(Si) / 4);
          D := (Source(Si) mod 4) * 16;
          Target(Last - 2) := To_String(D);
          Target(Last - 1) := '=';
          Target(Last) := '=';
          -- dddddd dd0000  = =
        when 1 =>
          D := D + Source(Si) / 16;
          Target(Last - 2) := To_String(D);
          D := (Source(Si) mod 16) * 4;
          Target(Last - 1) := To_String(D);
          -- dddddd dddddd dddd00 =
        when 2 =>
          D := D + Source(Si) / 64;
          Target(Last - 1) := To_String(D);
          Target(Last) := To_String(Source(Si) mod 64);
          -- dddddd dddddd dddddd dddddd
      end case;
      Slot := Slot + 1;
    end loop;
  end Encode;

end Base64;


with Base64,
     Ada.Streams,
     Ada.Streams.Stream_Io,
     Ada.Text_Io;
use Ada.Streams;
procedure Test64 is
  -- read N bytes from file "a", encode, decode, and see if original restored

  procedure Test(N : in Stream_Element_Offset) is
    Fd      : Stream_Io.File_Type;
    Output_Quad_Count: constant Integer := (Integer(N) + 2) / 3;
    Output_Byte_Count: constant Integer := 4 * Output_Quad_Count;
    Encoded : String(1 .. Output_Byte_Count + 2 * (Output_Byte_Count / 76));
    Last_E  : Integer;
    Buffer,
    Buffer2 : Stream_Element_Array(1 .. N);
    Last_D  : Stream_Element_Offset;
  begin
    Ada.Text_Io.Put_Line("test" & Stream_Element_Offset'Image(N));
    Stream_Io.Open(Fd, Stream_Io.In_File, "a");
    Stream_Io.Read(Fd, Buffer, Last_D);
    Base64.Encode(Buffer(1 .. Last_D), Encoded, Last_E);
    Ada.Text_Io.Put_Line("encoded in" & Integer'Image(Last_E));
    Ada.Text_Io.Put(Encoded(1 .. Last_E));
    Ada.Text_Io.New_Line;
    Base64.Decode(Encoded(1 .. Last_E), Buffer2, Last_D);
    if Last_D /= Buffer2'last then
      Ada.Text_Io.Put_Line(Stream_Element_Offset'Image(Last_D)
        & "/="
        & Stream_Element_Offset'Image(Buffer2'last));
    end if;
    if Buffer2(1 .. Last_D) /= Buffer then
      Ada.Text_Io.Put_Line("/=");
    end if;
    Stream_Io.Close(Fd);
  end Test;

begin

  for I in Stream_Element_Offset range 9 .. 14 loop
    Test(I);
  end loop;

  for I in Stream_Element_Offset range 252 .. 290 loop
    Test(I);
  end loop;

  for I in Stream_Element_Offset range 1 .. 9 loop
    Test(I);
  end loop;

end Test64;



--------------------------------------------------------------------------------
Additional functionality is available in code contributed by Darren New in base64.zip 
--------------------------------------------------------------------------------
Contributed by: Tom Moran
Contributed on: August 28, 2001
License: Public Domain

--------------------------------------------------------------------------------
Back 