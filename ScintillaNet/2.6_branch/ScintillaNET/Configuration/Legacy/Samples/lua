-- lll.lua an initialisation script for lll mode in SciTE

SETLINEINDENTATION = SCI_START + 126
GETLINEINDENTATION = SCI_START + 127
GETLINEINDENTPOSITION = SCI_START + 128
SETSEL = SCI_START + 160
LINEFROMPOSITION = SCI_START + 166
POSITIONFROMLINE = SCI_START + 167

function onExecute(s)
	local period = property("caret.period")
	trace("> [" .. s .. "  period:" .. period .. editor:range(0,3) .. "]\n")
end

-- Example styler looks for "lua" and highlights to end of word.
function onStyle(start,len,state,styler)
	--trace("> [" .. start .."," .. len .. "," .. startstyle .. "]\n")
	local i = start
    while i <= start + len do
		if strlower(editor:range(i,i+3)) == "lua" then
			styler:colourto(i - 1, state)
			state = 1
		elseif state == 1 then
			if not strfind(editor:range(i,i+1), "[%a_]") then
				styler:colourto(i - 1, state)
				state = 0
			end
		end
		i = i + 1
	end
	styler:colourto(start + len - 1, state)
	return 1
end

function setindent(line, indent)
	editor:send(SETLINEINDENTATION, line, indent)
	return editor:send(GETLINEINDENTPOSITION, line)
end

-- Example of indentation code
function onChar(ch)
	--trace("> onChar" .. ch .. "\n")
	local start, stop = editor:selection()
	if start == stop then
		local line = editor:send(LINEFROMPOSITION, start)
		local linestart = editor:send(POSITIONFROMLINE, line)
		local prevlinestart = editor:send(POSITIONFROMLINE, line-1)
		local prevline = editor:range(prevlinestart, linestart)
		local indent = editor:send(GETLINEINDENTATION, line-1)
		if ch == '\r' or ch == '\n' then 
			if start == linestart then
				prevline = gsub(prevline, "%c", "")		-- remove control characters
				prevline = gsub(prevline, "\".*\"", "")	-- remove strings
				prevline = gsub(prevline, "//.*", "")	-- remove comments
				if strfind(prevline, "{") then
					indent = indent + property("indent.size")
				end
				local pos = setindent(line, indent)
				editor:send(SETSEL, pos, pos)
			end
		elseif ch == '}' then
			indent = indent - property("indent.size")
			local pos = setindent(line, indent)
			editor:send(SETSEL, pos+1, pos+1)
		end
	end
	return 1
end
