/* --------------------------------------------------------------------------

Copyright (c) 2007 Declan Bright

This software is provided 'as-is', without any express or implied warranty. 
In no event will the authors be held liable for any damages arising from 
the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it freely, 
subject to the following restrictions:

    1. The origin of this software must not be misrepresented; you must not 
    claim that you wrote the original software. If you use this software in
    a product, an acknowledgment in the product documentation would be 
    appreciated but is not required.

    2. Altered source versions must be plainly marked as such, and must not 
    be misrepresented as being the original software.

    3. This notice may not be removed or altered from any source distribution.
 
--------------------------------------------------------------------------- */

<!--
    window.onload = setupPage;
    window.onresize = setupPage; 
    window.onscroll = setupPage;
    var tintDiv;
    var ww = 0, wh = 0;         // window dimensions
    var dw = 0, dh = 0          // document dimensions
    var sx = 0, sy = 0;         // scroll x & y
    var hh = 19;                // header height
    var pi = "Progress.gif";    // progress image path

    // Setup
    // ---------------------------------------------------   
     
    function setupPage() { 
        tintDiv = document.getElementById("modaltintdiv");     
        getDimensions();    
        sizeTintDiv();
        setModalPosition();
    }

    function getDimensions() {     
       // Window dimensions
       if (window.innerWidth) {
          ww = window.innerWidth;
          wh = window.innerHeight;      
       }
       else if (document.documentElement && document.documentElement.clientWidth && document.documentElement.clientHeight) {
          ww = document.documentElement.clientWidth;
          wh = document.documentElement.clientHeight;
       }
       else if (document.body && document.body.clientWidth && document.body.clientHeight) {
          ww = document.body.clientWidth;
          wh = document.body.clientHeight;
       }
       // Document dimensions
       if (document.documentElement && document.documentElement.scrollWidth && document.documentElement.scrollHeight) {
          dw = document.documentElement.scrollWidth;
          dh = document.documentElement.scrollHeight;
       }
       else if (document.body && document.body.scrollWidth && document.body.scrollHeight) {
          dw = document.body.scrollWidth;
          dh = document.body.scrollHeight;
       }
       else if (document.body && document.body.clientWidth && document.body.clientHeight) {
          dw = document.body.clientWidth;
          dh = document.body.clientHeight;
       }    
    }    
    
    function getScrollXY() {
        sx = 0, sy = 0;
        if( typeof( window.pageYOffset ) == 'number' ) {
            sy = window.pageYOffset;
            sx = window.pageXOffset;
        } else if( document.body && ( document.body.scrollLeft || document.body.scrollTop ) ) {
            sy = document.body.scrollTop;
            sx = document.body.scrollLeft;
        } else if( document.documentElement && ( document.documentElement.scrollLeft || document.documentElement.scrollTop ) ) {
            sy = document.documentElement.scrollTop;
            sx = document.documentElement.scrollLeft;
        }
    }
    

    // Modal functions  
    // ---------------------------------------------------

    function openModal(imageUrl, imageTitle, padding, ratio){          
        var width = 0;
        var height = 0;
        
        // Calculate size of modal
        if(wh > ww || ((wh - padding) / ratio > ww)){
            width = ww - padding;
            height = width * ratio;
        }
        else {
            height = wh - padding;
            width = height / ratio;            
        } 
        
        if(width > 0 && height > 0){
            openModalDim(imageUrl, imageTitle, width, height);  
        }    
    }
    
    function openModalDim(imageUrl, imageTitle, width, height){
        opacity("modaltintdiv", 0, 70, 400); 

        setModalSize(width, height);
        setModalPosition();
        
        setTimeout("opacity('modalouter', 0, 100, 200)", 200);         
        getImage('modalimage', imageUrl, imageTitle, width, height);
    }    
    
    function setModalSize(width, height)
    {
        var ms = document.getElementById("modalouter").style;       
        ms.width = width + "px";
        ms.height = (height + hh) + "px"; 
    }
    
    function setModalPosition()
    {
        var ms = document.getElementById("modalouter").style;            
        var h = ms.height.substring(0, ms.height.length - 2);
        var w = ms.width.substring(0, ms.width.length - 2);
        
        getScrollXY();
        ms.top = ((sy + wh / 2) - ((h - hh) / 2) - 10) + "px";
        ms.left = ((sx + ww / 2) - (w / 2) - 10 ) + "px";         
    }

    function closeModal(){        
        opacity("modalouter", 100, 0, 200); 
        opacity("modaltintdiv", 70, 0, 200); 
        setTimeout("document.getElementById('modalimage').src = ''", 200);
    }    
        
    function sizeTintDiv() {   
       tintDiv.style.height = ((wh > dh) ? wh : dh) + "px";
       tintDiv.style.width = ((ww > dw) ? ww : dw) + "px";
    }    
          	
    function getImage(placeHolder, imageUrl, imageTitle, width, height){        
        var pHolder = document.getElementById(placeHolder);    
        pHolder.width = 100;
        pHolder.height = 16;        
        pHolder.src = pi;        
        pHolder.style.margin = ((height / 2) - 8) + "px 0 0 0";      
        
        var img = document.createElement('img');
        img.onload = function(evt){ 
            pHolder.style.margin = "0 0 0 0";     
            pHolder.src = '';   
            pHolder.width = width;
            pHolder.height = height;
            pHolder.src = this.src;     
        }
        img.src = imageUrl;         
        
        document.getElementById('imageTitle').innerHTML = imageTitle;   
    }      
        
    function showIt(id) {   
       var object = document.getElementById(id);
       object.style.display = "block";        
    }

    function hideIt(id) {  
        var object = document.getElementById(id);          
        object.style.display = "none";
    }  
    
    
    // Fade functions
    // http://www.brainerror.net/scripts_js_blendtrans.php
    // ---------------------------------------------------
    
    function opacity(id, opacStart, opacEnd, millisec) {    
        var object = document.getElementById(id);
        if(opacStart == 0){
            changeOpac(0, id);
            showIt(id); 
        }
        else  if(opacEnd == 0){
            setTimeout("hideIt('" + id + "')", millisec); 
        }
        
        // Speed for each frame
        var speed = Math.round(millisec / 100);
        var timer = 0;

        // Determine the direction for the blending, if start and end are the same nothing happens
        if(opacStart > opacEnd) {
            for(i = opacStart; i >= opacEnd; i--) {
                setTimeout("changeOpac(" + i + ",'" + id + "')", (timer * speed));
                timer++;
            }
        } 
        else if(opacStart < opacEnd) {
            for(i = opacStart; i <= opacEnd; i++) {
                setTimeout("changeOpac(" + i + ",'" + id + "')", (timer * speed));
                timer++;
            }
        }       
    }    

    // Change the opacity for different browsers
    function changeOpac(opacity, id) {
        var object = document.getElementById(id).style;        
        object.opacity = (opacity / 100);
        object.MozOpacity = (opacity / 100);
        object.KhtmlOpacity = (opacity / 100);
        object.filter = "alpha(opacity=" + opacity + ")";
    }   
-->   