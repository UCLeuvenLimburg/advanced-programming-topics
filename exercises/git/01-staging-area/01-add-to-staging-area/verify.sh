#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ ! $(git ls-files | grep a.txt) ]]; then
  echo fail
else
  echo ok
fi

popd > /dev/null
