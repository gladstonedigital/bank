CC=/usr/bin/mcs
MONO=/usr/bin/mono

SRC_DIR = src
BIN_DIR = bin

MAIN_SOURCE = $(SRC_DIR)/Bank.cs
MAIN = $(BIN_DIR)/Bank.exe

DLL_SOURCES = $(filter-out $(MAIN_SOURCE),$(wildcard $(SRC_DIR)/*.cs))
DLL = $(BIN_DIR)/Bank.dll 

all: $(MAIN) 

$(MAIN): $(DLL) $(MAIN_SOURCE)
	TERM=xterm $(CC) -addmodule:$(DLL) $(MAIN_SOURCE) -out:$(MAIN)

$(DLL): $(DLL_SOURCES)
	TERM=xterm $(CC) $(DLL_SOURCES) -target:module -out:$@

clean:
	rm -f $(MAIN) $(DLL)

rebuild: clean all

test: $(MAIN)
	TERM=xterm $(MONO) $(MAIN)

.PHONY : clean test rebuild all
.SILENT : clean test
