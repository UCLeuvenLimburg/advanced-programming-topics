#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git branch | wc -l) != 1 ]]; then
  echo fail: expected only one branch to exist
elif [[ ! $(git branch | grep master) ]]; then
  echo fail: master should be only remaining branch
elif [[ $(cat file.txt | wc -l) != 3 ]]; then
  echo fail: file.txt should contain three lines
elif [[ $(cat file.txt | head -n 1) != "This should be line 1" ]]; then
  echo fail: file.txt first line is wrong
elif [[ $(cat file.txt | head -n 2 | tail -n 1) != "This should be line 2" ]]; then
  echo fail: file.txt second line is wrong
elif [[ $(cat file.txt | tail -n 1) != "This should be line 3" ]]; then
  echo fail: file.txt third line is wrong
else
  echo ok
fi

popd > /dev/null
