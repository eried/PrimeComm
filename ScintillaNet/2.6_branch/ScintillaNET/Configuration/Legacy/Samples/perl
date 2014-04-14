use Win32::ChangeNotify;
use Mail::Sendmail;
use Net::SNPP;  #
use strict;
my (@stat, $beginsize, $notify, $endsize, %mail,
	$to, $from, $directory, $file, $machine,
	$snpp, $pagerhost, $pager,
	@drwatson, $drw, $pid, $app,
	);
my $VERSION = 0.5;

$machine = 'machine';
$to = 'notify@address.com';
$from = "$machine\@address.com";
$directory = 'c:/winnt';
$file = 'c:/winnt/drwtsn32.log';

$pagerhost = 'pagerhost.server.com';   #
$pager = 'pagerID';					   #

print "Monitoring Dr Watson on $machine ...\n";

while (1)	{
	@stat = stat("$file");
	$beginsize=$stat[7];
	$notify = Win32::ChangeNotify->new($directory,0,'SIZE')
			or die "$^E";
	$notify->wait or warn "Something failed: $!\n";

	# There has been a change.
	@stat = stat($file);
	$endsize=$stat[7];

	# Did the Dr Watson log change?
	if ($beginsize != $endsize)	{
		print "Crash ...\n";

		open (DRW, $file);
		undef $/;
		$drw=<DRW>;
		close DRW;

		$drw =~ m/.*exception occurred:.*?pid=(\d+).*?\s+\1\s(.*?)\n/s;
		$pid = $1;
		$app = $2;
		print "The crash was in $app (PID $pid)\n";

		# Send notification
		%mail = (To => $to,
			From => $from,
			Subject => "Crash on $machine",
			Message => "$machine crash: $app."
			);
		sendmail(%mail) or die $Mail::Sendmail::error;
		print "Notification sent\n", $Mail::Sendmail::log;

		#  Or, send a page
		$snpp = Net::SNPP->new($pagerhost);	   #
		$snpp->send (Pager => $pager,		   #
					Message => "$machine crash: $app"  #
					);								  #
		
		print "Page sent to $pager.\n";				   #
	} #  End if

} #  Wend

=head1 NAME

drw_monitor - Report when an NT box crashes by watching the size
of the Dr Watson log.

=head1 DESCRIPTION

It is rather difficult to tell, sometimes, when an application has crashed
on an NT machine without actually looking at the screen. You can try to
ping, or even establish socket connections, but these can produce 
misleading results. If you have Dr Watson installed, you can use this 
script to monitor the size of the Dr Watson log, and send you email when
there is a crash, or send an alpha page.

=head1 PREREQUISITES

This script C<use>s C<Win32::ChangeNotify>, C<Mail::Sendmail>, and
C<Net::SNPP>. And, obviously, since it monitors
the Dr Watson log, it would help to have Dr Watson (or similar) installed.

=head1 Comments

If you don't have a pager server handy, and just want to use the email
portions of this, just comment out the lines that refer to the pager
stuff. I've indicated these lines by putting a # at the end of them.

For more details, especially about installing and running this, please
see http://www.rcbowen.com/imho/perl/CPAN/drw_monitor.html

=pod OSNAMES

MSWin32

=pod SCRIPT CATEGORIES

Win32

=cut