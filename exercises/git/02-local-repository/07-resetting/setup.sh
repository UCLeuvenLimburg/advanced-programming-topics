#/usr/bin/env bash

rm -rf sandbox
mkdir sandbox
pushd sandbox
git init

touch a.txt
git add a.txt
git commit -m 'First commit'

touch b.txt
git add b.txt
git commit -m 'Second commit'

touch c.txt
git add c.txt
git commit -m 'Third commit'

touch d.txt
git add d.txt
git commit -m 'Fourth commit'

popd
