#include <stdlib.h>

#ifdef USE_DOT_H
    #include <iostream.h>
#else
    #include <iostream>
    #if !defined( __BORLANDC__ ) || __BORLANDC__ >= 0x0530
        using namespace std;      // Borland has a bug
    #endif
#endif

#ifndef SAFE_STL
    #include <vector>
    using std::vector;
#else
    #include "vector.h"
    #include "StartConv.h"
#endif


// Generate numbers (from 1-100)
// Print number of occurrences of each number
int main( )
{
    const int DIFFERENT_NUMBERS = 100;

      // Prompt for and read number of games.
    int totalNumbers;
    cout << "How many numbers to generate?: ";
    cin >> totalNumbers;

    vector<int> numbers( DIFFERENT_NUMBERS + 1 );

      // Initialize the vector to zeros.
    for( int i = 0; i < numbers.size( ); i++ )
        numbers[ i ] = 0;

      // Generate the numbers.
    for( int j = 0; j < totalNumbers; j++ )
        numbers[ rand( ) % DIFFERENT_NUMBERS + 1 ]++;

      // Output the summary.
    for( int k = 1; k <= DIFFERENT_NUMBERS; k++ )
        cout << k << " occurs " << numbers[ k ]
                  << " time(s)\n";

    return 0;
}



#ifdef SAFE_STL
    #include "EndConv.h"
#endif


