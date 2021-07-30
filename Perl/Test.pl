# ---------------
# Import stuff
# ---------------

use feature ':5.10';
use feature "state";
use feature "switch";
use strict;
use warnings;
use diagnostics;

# --------------------
# Define variables
# --------------------


my ($name, $address)  =  ("Wither", "123 Boredom Street");
my $my_info           =  qq{$name lives on $address};  # qq{} method serves to embed variables into strings

# -----------------------------------
# Print the sentence to the screen
# ----------------------------------

say $my_info;
