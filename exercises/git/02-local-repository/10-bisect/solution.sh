#/usr/bin/env bash

pushd sandbox > /dev/null

# Start bisecting
git bisect start

# First commit should be registered as being good
git bisect good `git log --format=%H | tail -n 1`

# 6 has no special meaning, it just happens to be the number of iterations necessary for this specific exercise
for i in {1..6}; do
    if [[ $(source script.sh | grep bug) ]]; then
        git bisect bad
    else
        git bisect good
    fi
done

# Add tag
git tag bugged

# Reset everything to original state
git bisect reset

popd > /dev/null
