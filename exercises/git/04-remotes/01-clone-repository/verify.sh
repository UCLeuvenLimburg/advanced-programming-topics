#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ ! -d local ]]; then
  echo fail: no local directory found
elif [[ ! -d local/.git ]]; then
  echo fail: no repository found under local
elif [[ $(cd local; git log --format=%H) != $(cd remote; git log --format=%H) ]]; then
  echo fail: local and remote have different commits
else
  echo ok
fi

popd > /dev/null
