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
elif [[ $(cd local; git remote | grep origin | wc -l) != 1 ]]; then
  echo fail: local repo has no remote named origin
elif [[ $(cd local; git branch | wc -l) != 4 ]]; then
  echo fail: local repo should count 4 branches
elif [[ ! $(cd local; git branch | grep master) ]]; then
  echo fail: local repo should have master
elif [[ ! $(cd local; git branch | grep branch-a) ]]; then
  echo fail: local repo should have branch-a
elif [[ ! $(cd local; git branch | grep branch-b) ]]; then
  echo fail: local repo should have branch-b
elif [[ ! $(cd local; git branch | grep branch-c) ]]; then
  echo fail: local repo should have branch-c
elif [[ ! $(cd local; git checkout master; git rev-parse --abbrev-ref --symbolic-full-name @{u} | grep origin/master) ]]; then
  echo fail: local repo branch master should be tracking origin/master
elif [[ ! $(cd local; git checkout branch-a; git rev-parse --abbrev-ref --symbolic-full-name @{u} | grep origin/branch-a) ]]; then
  echo fail: local repo branch-a should be tracking origin/branch-a
elif [[ ! $(cd local; git checkout branch-b; git rev-parse --abbrev-ref --symbolic-full-name @{u} | grep origin/branch-b) ]]; then
  echo fail: local repo branch-b should be tracking origin/branch-b
elif [[ ! $(cd local; git checkout branch-c; git rev-parse --abbrev-ref --symbolic-full-name @{u} | grep origin/branch-c) ]]; then
  echo fail: local repo branch-c should be tracking origin/branch-c
else
  echo "ok"
fi

popd > /dev/null
