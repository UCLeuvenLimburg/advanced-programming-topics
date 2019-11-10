fn main() {
    let s1 = String::from("hello");
    add_exclamation(s1);
}

fn add_exclamation(s : String) {
    // fails to compile
    // push_str tries to modify s, but it received a readonly version of the string
    s.push_str("!");
}
