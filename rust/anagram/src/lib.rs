use std::collections::HashSet;

pub fn anagrams_for<'a>(word: &str, possible_anagrams: &[&'a str]) -> HashSet<&'a str> {
    let mut anagrams: HashSet<&'a str> = HashSet::new();

    for &w in possible_anagrams {
        let mut is_anagram = true;
        if w.to_lowercase() == word.to_lowercase() || w.len() != word.len() {
            continue;
        }
        for letter in w.to_lowercase().chars() {
            if !word.to_lowercase().contains(letter) || 
            word.to_lowercase().matches(letter).count()
            != w.to_lowercase().matches(letter).count(){
                is_anagram = false;
                break;
            }
        }
        if is_anagram {
            anagrams.insert(w);
        }
    }
    anagrams
}
