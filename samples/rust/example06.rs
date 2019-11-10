fn main() {
    let s1 = String::from("hello");

    // s1 is borrowed to print
    print(&s1);

    // s1 is still valid

    // s1 can be borrowed again to print
    print(&s1);

    // s1 is still valid
}

fn print(s : &String) {
    println!("The string's value is {}.", s);
}
