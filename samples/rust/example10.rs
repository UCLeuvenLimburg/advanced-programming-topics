fn main() {
    let mut s1 = String::from("hello");

    add_exclamation(&mut s1);

    println!("{}", s1);
}

fn add_exclamation(s : &mut String) {
    s.push_str("!");
}
