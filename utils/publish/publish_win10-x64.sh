#!/bin/bash

dotnet publish ../../src/Ropuszka.Migration.sln -c release -r win10-x64 --self-contained -o ../../build/win10-x64

exit 0

