#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ ! -d local ]]; then
  echo fail: no local directory found
elif [[ ! -d remote ]]; then
  echo fail: no remote directory found
elif [[ ! -d local/.git ]]; then
    echo fail: no repository found under local
elif [[ $(cd remote; git rev-parse --git-dir) != '.' ]]; then
    echo fail: no repository found under remote
elif [[ $(cd remote; git rev-parse --is-bare-repository) != true ]]; then
    echo fail: repo under remote is not bare
else
  echo "ok"
fi

popd > /dev/null
