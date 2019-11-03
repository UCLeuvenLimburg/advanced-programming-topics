#/usr/bin/env bash

pushd sandbox > /dev/null

if [[ ! -d local ]]; then
  echo fail: no local directory found
else
  cd local

  if [[ ! -d .git ]]; then
    echo fail: no repository found under local
  else
    echo "ok"
  fi
fi

popd > /dev/null
