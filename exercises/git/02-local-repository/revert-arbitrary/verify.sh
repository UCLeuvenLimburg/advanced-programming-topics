#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ $(git ls-files | grep a.txt) && $(git ls-files | grep b.txt) && $(git ls-files | grep d.txt) && ! $(git ls-files | grep c.txt) && $(git log --format=oneline | wc -l) == 5 ]]; then
  echo ok
else
  echo fail
fi

popd > /dev/null
