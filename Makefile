CC=mcs

MAIN_SOURCE = Bank.cs
MAIN = Bank.exe

DLL_SOURCES = $(filter-out $(MAIN_SOURCE),$(wildcard *.cs))
DLL = Bank.dll 

all: $(MAIN) 

$(MAIN): $(DLL) $(MAIN_SOURCE)
	$(CC) -addmodule:$(DLL) $(MAIN_SOURCE) -out:$(MAIN)

$(DLL): $(DLL_SOURCES)
	$(CC) $(DLL_SOURCES) -target:module -out:$@

clean:
	rm $(MAIN) $(DLL)

rebuild: clean all

.PHONY : clean
.SILENT : clean
