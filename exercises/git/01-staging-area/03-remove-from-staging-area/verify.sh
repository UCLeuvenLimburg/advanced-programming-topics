#/usr/bin/env bash

pushd sandbox > /dev/null

if [ -f password.txt ]; then
  if [[ $(git ls-files | grep password.txt) ]]; then
    echo fail: file still in staging area
  else
    echo ok
  fi
else
  echo fail: file removed from working area
fi

popd > /dev/null
