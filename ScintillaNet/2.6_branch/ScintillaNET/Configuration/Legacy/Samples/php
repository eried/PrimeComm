<?
/*
TDs Counter 1.0
Copyright 2000-2001 KMR Enterprises
Scripted by TDavid @ http://www.tdscripts.com/ 
http://www.php-scripts.com (Example #31,32)
Purpose: a mult-page counter system in PHP / mySQL

This code is made available freely to modify as long as
this COMPLETE header is not removed. If you decide to use this 
code then please put up a reciprocal link back to our site at
http://www.tdscripts.com/

We cannot, and will not, be held liable for any use or misuse
of the code contained herein. Any upload or execution of the
code implies understanding and agreement of these terms of use.
*/

$mysql_db = "DATABASE NAME";
$mysql_user = "YOUR MYSQL USERNAME";
$mysql_pass = "YOUR MYSQL PASSWORD";
$mysql_link = mysql_connect("localhost", $mysql_user, $mysql_pass);
mysql_select_db($mysql_db, $mysql_link);
$create_query = "CREATE TABLE tds_counter (
    COUNT_ID INT NOT NULL AUTO_INCREMENT,
    pagepath VARCHAR(250),
    impressions INT,
    reset_counter DATETIME,
    PRIMARY KEY (COUNT_ID)
    )";

mysql_query($create_query, $mysql_link);
print("Table Creation for <b>tds_counter</b> successful!<p>");

$insert = "INSERT into tds_counter VALUES (
    0, '/php_diary/021901.php3', 0, SYSDATE()
   )";

mysql_query($insert, $mysql_link);
print("Inserted new counter successfully for this page: http://www.php-scripts.com/php_diary/021901.php3<p>");

?> 