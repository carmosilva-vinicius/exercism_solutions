#[derive(Debug)]
pub struct Clock {
    minutes: i32,
}

impl Clock {
    pub fn new(hours: i32, minutes: i32) -> Self {
        let total_minutes = (hours * 60 + minutes).rem_euclid(1440);
        Self { minutes: total_minutes }
    }

    pub fn to_string(&self) -> String {
        format!("{}", self)
    }

    pub fn add_minutes(&self, minutes: i32) -> Self {
        Self::new(0, self.minutes + minutes)
    }
}

impl std::fmt::Display for Clock {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        write!(f, "{:02}:{:02}", self.minutes / 60, self.minutes % 60)
    }
}

impl PartialEq for Clock {
    fn eq(&self, other: &Self) -> bool {
        self.minutes == other.minutes
    }
}