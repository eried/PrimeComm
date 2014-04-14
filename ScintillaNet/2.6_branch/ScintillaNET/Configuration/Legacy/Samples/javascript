/*******************************************************************************
jMenus Version 1.0
Written by:
Justin Greenwood

Supports: Internet Explorer 5.x, Netscape 6.x

History:
2001/04/01 - Justin Greenwood - Added transparency filter for IE, left-side 
								navigation, and fixed a couple bugs
2001/04/03 - Justin Greenwood - Added Timeout for inactivity (hides menu)
*******************************************************************************/

var itemCounter = 0;

var timeOutHandle = null;
var timeOutTime = 500;

	function updateStatus() {
		itemCounter++;
		if (isMinIE4 || (isMinNS4 && !isMinNS6) ) {
			window.status = itemCounter + " Menus Created";
		}
	}

	function clickAnywhere(e) {
	if (isMinIE4) {
			theEvent = event;
			theElement = event.srcElement;
		} else if (isMinNS4) {
			theEvent = e;
			theElement = e.target;
		}

		if (isDOM && theElement.nodeType == 3 && theElement.nodeName == "#text") {
			theElement = getParent(theElement);	
		}
		
		if (theElement.tagName.toLowerCase() == "a") {
			theElement = getParent(theElement);
		}

		if (theElement.tagName.toLowerCase() == "div") {
			theId = theElement.id;
			if (myElements[theId] && myElements[theId].href != "") {
				window.location = (myElements[theId].href);
			}
		}
		
		hideAllMenus();
	
	}
	
	function hideAllMenus() {
		if (isMinIE4) showWindowedObjects(true);
		
		for (var element in myMenuRoots) {
			if (myMenuRoots[element].childrenShown)
				myMenuRoots[element].hideKids();
		}
	}

	function menuBar(theId, theColor, theBorder, x, y, w, h, z) {
		objectHandle = document.createElement("div");
		document.body.appendChild(objectHandle);
		this.obj = objectHandle;
		this.css = objectHandle.style;
		with (this.obj) {
			id = theId;
		}

		with (this.css) {	
			width = w;
			height = h;
			position = "absolute";
			border = theBorder;
		}
		moveLayerTo(this.obj, x, y);
		setzIndex(this.obj, z);
		showLayer(this.obj);
		setBgColor(this.obj, theColor);
		updateStatus();
	}

	function menuRootObj(theId, theTitle, theURL, x, y, w, h) {
		objectHandle = document.createElement("div");
		document.body.appendChild(objectHandle);
		this.obj = objectHandle;
		this.css = objectHandle.style;
		this.colorOn = MenuColor_On;
		this.colorOff = MenuColor_Off;
		this.active = false;
		this.kids = new Array();
		this.href = theURL;
		this.isParent = false;
		this.childrenShown = false;
		
		with (this.obj) {
			id = theId;
			alt = theTitle;
		}

		with (this.css) {	
			width = (w + 'px');
			height = (h + 'px');
			position = "absolute";
			cursor = "hand";
			textAlign = MenuTxtAlign;
			fontSize = MenuTxtFontSize;
			fontFamily = MenuTxtFont;
			textDecoration = MenuTxtFontDecor;
			fontWeight = MenuTxtFontWeight;
			border=MenuBorder;
			if (isMinIE55 && MenuOpacity < 100)
				filter="alpha(opacity=" + MenuOpacity + ")";
		}
	
		anchorHandle = document.createElement("a");
		this.obj.appendChild(anchorHandle);
		this.anchor = anchorHandle;
		with (this.anchor) {
			if (theURL != "")
				href = theURL;
			target = "_top";
			innerHTML = theTitle;
			style.fontSize = MenuTxtFontSize;
			style.fontFamily = MenuTxtFont;
			style.color = MenuTxtColor_Off;
			if (MenuTxtAlign == "left") {
				style.position = "absolute";
				style.paddingLeft = MenuTxtPaddingLeft;
			} else if (MenuTxtAlign == "right"){
				style.position = "relative";
				style.paddingRight = MenuTxtPaddingRight;
			} else {
				style.position = "relative";
			}
			style.top = MenuTxtPaddingTop;

			style.textDecoration = MenuTxtFontDecor;
			style.fontWeight = MenuTxtFontWeight;
		}
		
		moveLayerTo(this.obj, x, y);
		setzIndex(this.obj, MenuZIndex);
		showLayer(this.obj);
		setBgColor(this.obj, this.colorOff);
		
		// Properties
		this.h = h;
		this.w = w;
		this.x = x;
		this.y = y;
		
		// Events
		this.obj.onmouseover = mnu_over;
		this.anchor.onmouseover = mnu_over;
		
		this.obj.onmouseout = mnu_out;
		
		// Methods
		this.addSubItem = mnu_AddChild;
		this.showKids = mnu_ShowKids;
		this.hideKids = mnu_HideKids;
		
		this.glow = glow;
		this.dim = dim;
		updateStatus();
	}
	
	function mnu_AddChild(objChild) {
		var currentCount = this.kids.length;
		objChild.mommy = this;

		if (this.isParent == false) {
			this.isParent = true;
		}
				
		var totalSize = 0;
		if (MainMenuType == "right") {
			objChild.x = this.x + this.w;
			
			for (var i = 0; i < currentCount; i++) {
				totalSize += this.kids[i].h;
			}
			objChild.y = this.y + totalSize;
		} else {
			objChild.x = this.x;
			
			for (var i = 0; i < currentCount; i++) {
				totalSize += this.kids[i].h;
			}
			objChild.y = this.h + this.y + totalSize;			
		}

		moveLayerTo(objChild.obj, objChild.x, objChild.y);
		
		this.kids[currentCount] = objChild;
	}
	
	function mnu_ShowKids() {
		var currentCount = this.kids.length;

		hideAllMenus();

		if (currentCount > 0) {
			this.childrenShown = true;
		}

		if (isMinIE4) showWindowedObjects(false);
		for (var i = 0; i < currentCount; i++) {
			showLayer(this.kids[i].obj);
		}
	}
	
	function mnu_HideKids() {
		var currentCount = this.kids.length;
		if (isMinIE4) showWindowedObjects(true);

		this.childrenShown = false;
		for (var i = 0; i < currentCount; i++) {
			hideLayer(this.kids[i].obj);
			if (this.kids[i].kids.length > 0) {
				this.kids[i].hideKids();
			}
		}
	}
	
	function mnu_over(e) {
		if (isMinIE4) {
			theElement = event.srcElement;
		} else if (isMinNS4) {
			theElement = e.target;
		}
		if (isDOM && theElement.nodeType == 3 && theElement.nodeName == "#text") {
			theElement = getParent(theElement);	
		}
		if (theElement.tagName.toLowerCase() == "a") {
			theElement.style.color=MenuTxtColor_On;
			theElement = getParent(theElement);

		}
		if (theElement.tagName.toLowerCase() == "div") {
			theId = theElement.id;
			myMenuRoots[theId].showKids();
			myMenuRoots[theId].anchor.style.color=MenuTxtColor_On;
			myMenuRoots[theId].glow();
			clearTimeout(timeOutHandle);
		}
	}

	function mnu_out(e) {
		if (isMinIE4) {
			theElement = event.srcElement;
			scrY = event.clientY + document.body.scrollTop;
			scrX = event.clientX + document.body.scrollTop;
		} else if (isMinNS4) {
			theElement = e.target;
			scrY = parseInt(e.pageY) + document.body.scrollTop;
			scrX = parseInt(e.pageX) + document.body.scrollTop;
		}
		if (isDOM && theElement.nodeType == 3 && theElement.nodeName == "#text") {
			theElement = getParent(theElement);	
		}
		if (theElement.tagName.toLowerCase() == "a") {
			theElement.style.color = MenuTxtColor_Off;
			theElement = getParent(theElement);
			
		}
		if (theElement.tagName.toLowerCase() == "div") {
			theId = theElement.id;

			elem = myMenuRoots[theId];
			elem.anchor.style.color = MenuTxtColor_Off;
			elem.dim();
			elem.active = false;
			
			var currentCount = elem.kids.length;


			if (MainMenuType == "right") {
				var rightSide = elem.x + elem.w;
				var kidsActive = false;
				for (var i = 0; i < currentCount; i++) {
					if (elem.kids[i].active) {
						kidsActive = true;
						break;
					}
				}
				if (!kidsActive && rightSide > scrX) {
					elem.hideKids();
				}
			} else {
				var bottomSide = elem.y + elem.h;
				var kidsActive = false;
				for (var i = 0; i < currentCount; i++) {
					if (elem.kids[i].active) {
						kidsActive = true;
						break;
					}
				}
			
				if (!kidsActive && bottomSide > scrY) {
					elem.hideKids();
				}
			}
			clearTimeout(timeOutHandle);
			timeOutHandle = setTimeout("hideAllMenus();", timeOutTime);
		}
	}

	function menuChild(theId, theTitle, theURL, w, h, ovrdColor_off, ovrdColor_on) {
		objectHandle = document.createElement("div");
		document.body.appendChild(objectHandle);
		this.obj = objectHandle;
		this.css = objectHandle.style;
		if (ovrdColor_off) {
			this.colorOff = ovrdColor_off;
			if (ovrdColor_on) {
				this.colorOn = ovrdColor_on;
			} else {
				this.colorOn = ovrdColor_off;
			}
		} else {
			this.colorOn = ChildColor_On;
			this.colorOff = ChildColor_Off;
		}
		this.active = false;
		this.kids = new Array(); 
		this.mommy = null;
		this.href = theURL;
		this.isParent = false;
		this.childrenShown = false;
		
		with (this.obj) {
			id = theId;
			alt = theTitle;
		}

		with (this.css) {	
			width = (w + 'px');
			height = (h + 'px');
			position = "absolute";
			cursor = "hand";
			textAlign = ChildTxtAlign;;
			fontSize = ChildTxtFontSize;
			border = ChildBorder;
			if (isMinIE55 && ChildOpacity < 100)
				filter="alpha(opacity=" + ChildOpacity + ")";
		}

		anchorHandle = document.createElement("a");
		this.obj.appendChild(anchorHandle);
		this.anchor = anchorHandle;
		with (this.anchor) {
			if (theURL != "")
				href = theURL;
			target = "_top";
			innerHTML = theTitle;
			style.fontSize = ChildTxtFontSize;
			style.fontFamily = ChildTxtFont;
			style.color = ChildTxtColor_Off;
			style.position = "absolute";
			if (ChildTxtAlign == "left") {
				style.position = "absolute";
				style.paddingLeft = ChildTxtPaddingLeft;
			} else if (MenuTxtAlign == "right"){
				style.position = "relative";
				style.paddingRight = ChildTxtPaddingRight;
			} else {
				style.position = "relative";
			}
			style.top = ChildTxtPaddingTop;
			style.textDecoration = ChildTxtFontDecor;
			style.fontWeight = ChildTxtFontWeight;
		}	

		setzIndex(this.obj, ChildZIndex);
		hideLayer(this.obj);
		setBgColor(this.obj, this.colorOff);

		// Properties
		this.h = h;
		this.w = w;
		this.x = 0;
		this.y = 0;
		
		// Events
		this.obj.onmouseover = sub_over;
		this.anchor.onmouseover = sub_over;
		
		this.obj.onmouseout = sub_out;
		
		// Methods
		this.addSubItem = sub_AddChild;
		this.showKids = sub_ShowKids;
		this.hideKids = sub_HideKids;
		this.hideBrothersKids = sub_HideBrothersKids;
		this.showArrow = sub_ShowArrow;
		this.glow = glow;
		this.dim = dim;
		updateStatus();
	}
	
	function sub_ShowArrow () {
		theX = (this.x + this.w);
		imageHandle = document.createElement("img");
		this.obj.appendChild(imageHandle);
		imageHandle.src = ChildArrowImage;
		with (imageHandle.style) {
			position = "absolute";
			right = ( (2) + "px");
			top = ( ( (this.h - ChildArrowImageHeight) / 2)+"px");
		}
	}
	
	function sub_AddChild(objChild) {
		var currentCount = this.kids.length;
		
		if (this.isParent == false) {
			this.isParent = true;
			this.showArrow();
		}
		
		objChild.mommy = this;
		objChild.x = this.x + this.w;
		
		var totalSize = 0;
		for (var i = 0; i < currentCount; i++) {
			totalSize += this.kids[i].h;
		}
		objChild.y = this.y + totalSize;
		
		moveLayerTo(objChild.obj, objChild.x, objChild.y);
		
		this.kids[currentCount] = objChild;
		
	}
	
	function sub_ShowKids() {
		var currentCount = this.kids.length;
		
		if (currentCount > 0) {
			this.hideBrothersKids();
			this.childrenShown = true;
		}
		
		for (var i = 0; i < currentCount; i++) {
			showLayer(this.kids[i].obj);
		}
	}
	
	function sub_HideKids() {
		var currentCount = this.kids.length;
		
		this.childrenShown = false;
		for (var i = 0; i < currentCount; i++) {
			hideLayer(this.kids[i].obj);
			if (this.kids[i].kids.length > 0 && this.kids[i].childrenShown) {
				this.kids[i].hideKids();
			}
		}
	}
	
	function sub_HideBrothersKids() {
		var currentKids = this.mommy.kids;
		var currentCount = currentKids.length;

		for (var i = 0; i < currentCount; i++) {
			if (currentKids[i].childrenShown && currentKids[i].isParent) {
				for (var j = 0; j < currentKids[i].kids.length; j++) {
					hideLayer(currentKids[i].kids[j].obj);
					if (currentKids[i].kids[j].childrenShown && currentKids[i].kids[j].isParent) {
						currentKids[i].kids[j].hideKids();
					}
				}
			}
		}
	}

	function sub_over(e) {
		if (isMinIE4) {
			theElement = event.srcElement;
		} else if (isMinNS4) {
			theElement = e.target;
		}
		
		if (isDOM && theElement.nodeType == 3 && theElement.nodeName == "#text") {
			theElement = getParent(theElement);	
		}
		
		if (theElement.tagName.toLowerCase() == "a" || theElement.tagName.toLowerCase() == "img") {
			theElement.style.color = ChildTxtColor_On;
			theElement = getParent(theElement);
		}

		if (theElement.tagName.toLowerCase() == "div") {
			theId = theElement.id;
			
			myElements[theId].active = true;
			myElements[theId].glow();
			myElements[theId].showKids();
			myElements[theId].anchor.style.color=ChildTxtColor_On;
			clearTimeout(timeOutHandle);
		}
	}
	
	function sub_out(e) {
		if (isMinIE4) {
			theElement = event.srcElement;
			scrX = event.clientX + document.body.scrollTop;
		} else if (isMinNS4) {
			theElement = e.target;
			scrX = parseInt(e.pageX) + document.body.scrollTop;
		}
		if (isDOM && theElement.nodeType == 3 && theElement.nodeName == "#text") {
			theElement = getParent(theElement);	
		}
		if (theElement.tagName.toLowerCase() == "a" || theElement.tagName.toLowerCase() == "img") {
			theElement.style.color=ChildTxtColor_Off;
			theElement = getParent(theElement);
		}
		if (theElement.tagName.toLowerCase() == "div") {
			theId = theElement.id;
			
			elem = myElements[theId];
			elem.anchor.style.color = ChildTxtColor_Off;
			elem.active = false;
			elem.dim();
			
			var currentCount = elem.kids.length;
			
			var rightSide = elem.x + elem.w;
			var kidsActive = false;
			for (var i = 0; i < currentCount; i++) {
				if (elem.kids[i].active) {
					kidsActive = true;
					break;
				}
			}
			if (!kidsActive && rightSide > scrX) {
				elem.hideKids();
			}
			clearTimeout(timeOutHandle);
			timeOutHandle = setTimeout("hideAllMenus();", timeOutTime);
		}
	}

	function glow() {
		setBgColor(this.obj, this.colorOn);
	}
	
	function dim(){
		setBgColor(this.obj, this.colorOff);
	}

/*********************************************************************************************
Added by Justin Greenwood   3/30/2001
 - This function is used for hiding windowed controls because they interfere with the menus
*********************************************************************************************/
function showWindowedObjects(show) {
	var windowedObjectTags = new Array("SELECT", "IFRAME", "OBJECT", "APPLET","EMBED");
	var windowedObjects = new Array();
	var j=0;

	for (var i=0; i<windowedObjectTags.length; i++) {
		if (isMinIE4) var tmpTags = document.all.tags(windowedObjectTags[i]);
		else var tmpTags = getElementsByTagName(windowedObjectTags[i]);

		if (tmpTags.length > 0) {
			for (var k=0; k<tmpTags.length; k++) {
				windowedObjects[j++] = tmpTags[k];
			}
		}
	}

	for (var i=0; i < windowedObjects.length; i++) {
		if (!show) windowedObjects[i].style.visibility = "hidden";
		else windowedObjects[i].style.visibility = "visible";
	}
}
