fn main() {
    let s1 = String::from("hello");
    let s2 = s1; // s1 is *moved* to s2

    // Compiler error: s1 has become invalid
    println!("The string s1 is {}.", s1);

    println!("The string s2 is {}.", s2);
}
