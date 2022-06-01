//https://leetcode.com/problems/design-phone-directory/

import java.util.*;

public class PhoneBook {
    LinkedList<String> availableNumbers;
    Set<String> availableNumbersSet;
    int capacity;

    public PhoneBook(int maxNumbers) {
        capacity = maxNumbers;
        availableNumbers = new LinkedList<>();
        availableNumbersSet = new HashSet<>();
    }

    public String get() {
        if(availableNumbersSet.isEmpty()) {
            return "No numbers to give";
        }
        String number = availableNumbers.poll();
        availableNumbersSet.remove(number);
        return number;
    }

    public boolean check(String numberToCheck) {
        return availableNumbersSet.contains(numberToCheck);
    }

    public boolean release(String numberToRelease) {
        if(!availableNumbersSet.contains(numberToRelease) && availableNumbers.size() == capacity) {
            return false;
        }

        if(availableNumbersSet.contains(numberToRelease)) {
            return true;
        }
        availableNumbers.add(numberToRelease);
        availableNumbersSet.add(numberToRelease);
        return true;
    }
}
