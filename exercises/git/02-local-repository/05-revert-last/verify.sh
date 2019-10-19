#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git log --format=oneline | wc -l) == 5 ]]; then
  if [[ $(cat file.txt) == third ]]; then
    echo ok
  else
    echo fail: expected file.txt to contain \"third\"
  fi
else
  echo fail: five commits expected
fi

popd > /dev/null
