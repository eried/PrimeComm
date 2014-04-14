%% Sample code for the GTH API (Erlang version)
%%
%% Use:
%%       minimum:go(Hostname).
%%
%% type 'flush()' at the shell to see the GTH's response
%%
%% For the curious: Erlang is a concurrent, distributed functional language
%% which supports some really nifty things like being able to load new
%% code into a running program. You can get a copy of Open Source Erlang
%% from www.erlang.org (for free).
%%
%% A real system would parse the GTH's answer. The xmerl XML parser,
%% which is on the contributions page at www.erlang.org does this
%% very nicely. 
%%
-module(minimum).
-author('matthias@corelatus.com').
-export([go/0, go/1]).

go() -> go("localhost").

port() -> 2089.

go(Hostname) ->
	{ok, S} = gen_tcp:connect(Hostname, port(), []),
	Request = "<new>" 
		    "<connection>" 
		    "<pcm_source span=\"2A\" timeslot=\"4\"/>" 
		    "<pcm_sink   span=\"2A\" timeslot=\"4\"/>"
		    "</connection>" 
		    "</new>",
	ok = gen_tcp:send(S, "Content-type: text/xml\r\n"),
	ok = gen_tcp:send(S, "Content-length: " ++ 
		integer_to_list(length(Request)) ++ "\r\n\r\n"),
	ok = gen_tcp:send(S, Request).

