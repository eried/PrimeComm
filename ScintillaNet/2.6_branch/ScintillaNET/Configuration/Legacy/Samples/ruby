# Copyright 2004-2005, @Last Software, Inc.

# This software is provided as an example of using the Ruby interface
# to SketchUp.

# Permission to use, copy, modify, and distribute this software for 
# any purpose and without fee is hereby granted, provided that the above
# copyright notice appear in all copies.

# THIS SOFTWARE IS PROVIDED "AS IS" AND WITHOUT ANY EXPRESS OR
# IMPLIED WARRANTIES, INCLUDING, WITHOUT LIMITATION, THE IMPLIED
# WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
#-----------------------------------------------------------------------------
# Name        :   Rotated Rectangle Tool 1.0
# Description :   A tool to create rotated rectangles with the mouse.
# Menu Item   :   Draw->Rotated Rectangle
# Context Menu:   NONE
# Usage       :   This rectangle tool takes three points.
#             :   The first point is the first corner of the rectangle
#             :   The second point defines the direction of one of the sides
#             :   The third point defines the opposite side.
# Date        :   9/14/2004
# Type        :   Tool
#-----------------------------------------------------------------------------

require 'sketchup.rb'

#=============================================================================

class RectangleTool

def initialize
    @ip = Sketchup::InputPoint.new
    @ip1 = Sketchup::InputPoint.new
    reset
end

def reset
    @pts = []
    @state = 0
    @ip1.clear
    @drawn = false
    Sketchup::set_status_text "", SB_VCB_LABEL
    Sketchup::set_status_text "", SB_VCB_VALUE
    Sketchup::set_status_text "Click for start point"
    @shift_down_time = Time.now
end

def activate
    self.reset
end

def deactivate(view)
    view.invalidate if @drawn
end

def set_current_point(x, y, view)
    if( !@ip.pick(view, x, y, @ip1) )
        return false
    end
    need_draw = true
    
    # Set the tooltip that will be displayed
    view.tooltip = @ip.tooltip
        
    # Compute points
    case @state
    when 0
        @pts[0] = @ip.position
        @pts[4] = @pts[0]
        need_draw = @ip.display? || @drawn
    when 1
        @pts[1] = @ip.position
        @width = @pts[0].distance @pts[1]
        Sketchup::set_status_text @width.to_s, SB_VCB_VALUE
    when 2
        pt1 = @ip.position
        pt2 = pt1.project_to_line @pts
        vec = pt1 - pt2
        @height = vec.length
        if( @height > 0 )
            # test for a square
            square_point = pt2.offset(vec, @width)
            if( view.pick_helper.test_point(square_point, x, y) )
                @height = @width
                @pts[2] = @pts[1].offset(vec, @height)
                @pts[3] = @pts[0].offset(vec, @height)
                view.tooltip = "Square"
            else
                @pts[2] = @pts[1].offset(vec)
                @pts[3] = @pts[0].offset(vec)
            end
        else
            @pts[2] = @pts[1]
            @pts[3] = @pts[0]
        end
        Sketchup::set_status_text @height.to_s, SB_VCB_VALUE
    end

    view.invalidate if need_draw
end

def onMouseMove(flags, x, y, view)
    self.set_current_point(x, y, view)
end

def create_rectangle
    # check for zero height
    if( @pts[0] != @pts[3] )
        Sketchup.active_model.active_entities.add_face @pts
    end
    self.reset
end

def increment_state
    @state += 1
    case @state
    when 1
        @ip1.copy! @ip
        Sketchup::set_status_text "Click for second point"
        Sketchup::set_status_text "Width", SB_VCB_LABEL
        Sketchup::set_status_text "", SB_VCB_VALUE
    when 2
        @ip1.clear
        Sketchup::set_status_text "Click for third point"
        Sketchup::set_status_text "Height", SB_VCB_LABEL
        Sketchup::set_status_text "", SB_VCB_VALUE
    when 3
        self.create_rectangle
    end
end

def onLButtonDown(flags, x, y, view)
    self.set_current_point(x, y, view)
    self.increment_state
    view.lock_inference
end

def onCancel(flag, view)
    view.invalidate if @drawn
    self.reset
end

# This is called when the user types a value into the VCB
def onUserText(text, view)
    # The user may type in something that we can't parse as a length
    # so we set up some exception handling to trap that
    begin
        value = text.to_l
    rescue
        # Error parsing the text
        UI.beep
        value = nil
        Sketchup::set_status_text "", SB_VCB_VALUE
    end
    return if !value
    
    case @state
    when 1
        # update the width
        vec = @pts[1] - @pts[0]
        if( vec.length > 0.0 )
            vec.length = value
            @pts[1] = @pts[0].offset(vec)
            view.invalidate
            self.increment_state
        end
    when 2
        # update the height
        vec = @pts[3] - @pts[0]
        if( vec.length > 0.0 )
            vec.length = value
            @pts[2] = @pts[1].offset(vec)
            @pts[3] = @pts[0].offset(vec)
            self.increment_state
        end
    end
end

def getExtents
    bb = Geom::BoundingBox.new
    case @state
    when 0
        # We are getting the first point
        if( @ip.valid? && @ip.display? )
            bb.add @ip.position
        end
    when 1
        bb.add @pts[0]
        bb.add @pts[1]
    when 2
        bb.add @pts
    end
    bb
end

def draw(view)
    @drawn = false
    
    # Show the current input point
    if( @ip.valid? && @ip.display? )
        @ip.draw(view)
        @drawn = true
    end

    # show the rectangle
    if( @state == 1 )
        # just draw a line from the start to the end point
        view.set_color_from_line(@ip1, @ip)
        inference_locked = view.inference_locked?
        view.line_width = 3 if inference_locked
        view.draw(GL_LINE_STRIP, @pts[0], @pts[1])
        view.line_width = 1 if inference_locked
        @drawn = true
    elsif( @state > 1 )
        # draw the curve
        view.drawing_color = "black"
        view.draw(GL_LINE_STRIP, @pts)
        @drawn = true
    end
end

def onKeyDown(key, rpt, flags, view)
    if( key == CONSTRAIN_MODIFIER_KEY && rpt == 1 )
        @shift_down_time = Time.now
        
        # if we already have an inference lock, then unlock it
        if( view.inference_locked? )
            view.lock_inference
        elsif( @state == 0 )
            view.lock_inference @ip
        elsif( @state == 1 )
            view.lock_inference @ip, @ip1
        end
    end
end

def onKeyUp(key, rpt, flags, view)
    if( key == CONSTRAIN_MODIFIER_KEY &&
        view.inference_locked? &&
        (Time.now - @shift_down_time) > 0.5 )
        view.lock_inference
    end
end

end # of class RectangleTool

#=============================================================================

# Add a menu choice
if( not $rectangle_menu_loaded )
    add_separator_to_menu("Draw")
    UI.menu("Draw").add_item("Rotated Rectangle") {
        Sketchup.active_model.select_tool RectangleTool.new }
    $rectangle_menu_loaded = true
end
