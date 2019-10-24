#/usr/bin/env bash

pushd sandbox > /dev/null

if [ ! -f password.txt ]; then
  echo fail: password.txt not present in working area
elif [[ $(git ls-files | grep password.txt) ]]; then
  echo fail: password.txt still in staging area
else
  echo ok
fi

popd > /dev/null
