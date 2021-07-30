--[[
          ASK INPUT FROM THE USER
   We do this by first writing text to the screen. We then make a variable, and set its values to whatever the user 
   responds to the program, converted from a string (text) to a number (a mathematical number).
]]

io.write("Hello there, General Kenobi. I see that you wish to apply for a driver's license. How old are you?  ");
AbleToDrive = tonumber(io.read());

--[[
          CHECK RESULTS
    If the input is the number 18 or something higher, the user is of legal driving age and may take the exam.
    Minors may not drive (People can drive at age 16 in some countries, but not in mine), so if the supplied age
    is lower than 18, we prevent them from taking the exam and send them home instead.
]]

if (AbleToDrive >= 18) then
	io.write("Congratulations! Please go down the door on the right to prepare your exam.");

elseif (AbleToDrive < 18) then
	io.write("I'm sorry. Minors are not eligible to drive motor vehicles.");
	
end;

--[[
         KEEP PROGRAM OPEN
    If this line isn't here, the program will immediately close itself after you reply with a number.
    We don't actually read any further input; using this line in this fashion tricks the program into
    awaiting another key press before closing. It's a bit of a hack. This method is preferable to using
    os.execute 'pause' because the latter method displays additional text, whereas this does not.
]]

io.read();
