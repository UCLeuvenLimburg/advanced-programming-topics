fn main() {
    let s1 = String::from("hello");

    // Ownership is given to print, but it is also returned to us
    let s2 = print(s1);

    // s1 is invalid
    // s2 is valid
    print(s2);
}

fn print(s : String) -> String {
    println!("The string's value is {}.", s);

    // Returns s
    s
}
