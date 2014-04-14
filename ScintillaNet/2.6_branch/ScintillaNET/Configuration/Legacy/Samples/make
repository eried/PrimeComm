#-----Macros---------------------------------

# for cs machines
#BASEDIR = /usr/project/courses/cps008/lib
# for acpub machines
BASEDIR = /afs/acpub.duke.edu/users8/ola/courses/lib

TLIB = $(BASEDIR)/libtapestry.a
INCLUDES = -I. -I$(BASEDIR)

# set up compiler and options
CXX = g++
CXXFLAGS = -g $(INCLUDES)

#-----Suffix Rules---------------------------
# set up C++ suffixes and relationship between .cc and .o files

.SUFFIXES: .cc

.cc.o:
   ->   $(CXX) $(CXXFLAGS) -c $<

.cc :
   ->   $(CXX) $(CXXFLAGS) $< -o $@ -lm $(TLIB) -lg++

#-----File Dependencies----------------------

SRC = application.cc menu.cc menuitem.cc pixmap.cc usepix.cc \
      readcommand.cc quitcommand.cc filelister.cc templateapp.cc \
      displaycommand.cc

OBJ = $(addsuffix .o, $(basename $(SRC)))

usepix: $(OBJ)
   ->   $(CXX) $(CXXFLAGS) -o $@ $(OBJ) -lm $(TLIB) -lg++

#-----Other stuff----------------------------
depend:
   ->   makedepend $(CXXFLAGS) -Y $(SRC)

clean:
   ->   rm -f $(OBJ)
