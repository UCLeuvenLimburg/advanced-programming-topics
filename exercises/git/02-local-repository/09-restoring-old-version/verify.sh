#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(cat file.txt) != second ]]; then
  echo file.txt contains wrong data
elif [[ ! $(git status --porcelain) == 'M  file.txt' ]]; then
  echo Staging area should contain most recent version of file.txt
else
  echo ok
fi

popd > /dev/null
