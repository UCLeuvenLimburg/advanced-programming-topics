fn main() {
    let s1 = String::from("hello");

    // Transfers ownership
    add_exclamation(s1);

    // s1 has become invalid
    println!("{}", s1);
}

// Function signature expresses that its parameter will be modified
fn add_exclamation(mut s : String) {
    s.push_str("!");
}
