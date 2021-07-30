# -------------------------------------------------------------------
# This is a small little script I wrote for a friend.
# She wanted to impress her girlfriend, who is tech-savvy
# and loves programming. It's pretty wholesome, if you ask me.
# ------------------------------------------------------------------

use feature ':5.10';
use feature "state";
use feature "switch";
use strict;
use warnings;
use diagnostics;

my $gf    = "Erena";
my $love  = qq{
                  ####     ####
                ######## ########
               ##     #####     ##
               ##       #       ##
               ##               ##
               ##  I love you,  ##
               ##      $gf    ##  
               ###             ###
                ###          ###
                 ###       ###
                    #######
                       #
};  # Contrary to what it looks like, the heart renders fine in the window. I had to write it with part of the right wall caved in.

say ($love);
<>; # Await user input before closing the window
