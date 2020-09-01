Application Architecture Details

Program.cs
----------
    This is the entry point of the application.  If the programs parameters are passed in
via the command line the application uses those parameters.  Otherwise, the user
is prompted to enter the parameters. 
    The main logic of the application controlling the conversion of a file is also found
here, although it could be moved to it's own class to enable different frontends to be 
used in future.

Converter.cs
------------
Handles the overall conversion processing.
Is decoupled from the actual file formats by using a builder interface.

Builders
--------
BaseBuilder.cs 
    This is the abstract base class for all the builders and does the column name processing
JSONBuilder.cs
    Responsible for constructing a JSON string
XMLBuilder.cs
    Responsible for constructing an XML string

Repositories
------------
CSVRepository.cs
    Reads in a CSV file 
JSONRepository.cs
    Writes out a JSON file
XMLRepository.cs
    Writes out an XML file

Services
--------
Responsible for decoupling the application from the physical file handling and format

CSVService.cs
    Responsible for returning data from the CSVRepository
JSONService.cs
    Responsible for passing data to be JSONRepository
XMLService.cs
    Responsible for passing data to be XMLRepository


Interfaces
----------
IBuilder.cs 
IService.cs
    parameters are generically defined to allow new data types to be processed in future
