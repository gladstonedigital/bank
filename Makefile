CC=mcs

SRC_DIR = src
BIN_DIR = bin

MAIN_SOURCE = $(SRC_DIR)/Bank.cs
MAIN = $(BIN_DIR)/Bank.exe

DLL_SOURCES = $(filter-out $(SRC_DIR)/$(MAIN_SOURCE),$(wildcard $(SRC_DIR)/*.cs))
DLL = $(BIN_DIR)/Bank.dll 

all: $(MAIN) 

$(MAIN): $(DLL) $(MAIN_SOURCE)
	$(CC) -addmodule:$(DLL) $(MAIN_SOURCE) -out:$(MAIN)

$(DLL): $(DLL_SOURCES)
	$(CC) $(DLL_SOURCES) -target:module -out:$@

clean:
	rm -f $(MAIN) $(DLL)

rebuild: clean all

test: $(MAIN)
	$(MAIN)

.PHONY : clean test rebuild all
.SILENT : clean test
