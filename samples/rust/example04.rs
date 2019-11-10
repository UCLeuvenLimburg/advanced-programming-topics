fn main() {
    let s1 = String::from("hello");

    // Ownership is passed to print
    print(s1);

    // At this point, s1 has become invalid
    print(s1);
}

fn print(s : String) {
    println!("The string's value is {}.", s);
}
