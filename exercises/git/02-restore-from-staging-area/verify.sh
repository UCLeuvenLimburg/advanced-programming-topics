#/usr/bin/env bash

pushd sandbox > /dev/null

if [ -f ampharos.txt ]; then
  echo ok
else
  echo fail
fi

popd > /dev/null
