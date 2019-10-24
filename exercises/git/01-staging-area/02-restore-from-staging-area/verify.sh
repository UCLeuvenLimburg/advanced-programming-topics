#/usr/bin/env bash

pushd sandbox > /dev/null

if [ ! -f ampharos.txt ]; then
  echo fail: file ampharos.txt not found
else
  echo ok
fi

popd > /dev/null
