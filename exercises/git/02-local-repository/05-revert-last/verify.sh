#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=oneline | wc -l) != 5 ]]; then
  echo fail: five commits expected
elif [[ $(cat file.txt) != third ]]; then
  echo fail: expected file.txt to contain \"third\"
else
  echo ok
fi

popd > /dev/null
