#!/bin/bash

dotnet publish ../../src/Ropuszka.Migration.sln -c release -r linux-x64 --self-contained -o ../../build/linux-x64

exit 0

