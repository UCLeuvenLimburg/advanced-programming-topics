#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git ls-files | grep a.txt) ]]; then
  echo "ok"
else
  echo "fail"
fi

popd > /dev/null
