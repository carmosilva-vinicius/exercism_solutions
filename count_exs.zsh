#!/bin/zsh

for dir in */; do
    subdirs=$(find "$dir" -mindepth 1 -maxdepth 1 -type d | wc -l)
    if [[ -e "./README.md" ]]; then
        sed -i "/^${dir%/}: /d" "./README.md"
    fi
    echo "${dir%/}: $subdirs\n" >> "./README.md"
done

