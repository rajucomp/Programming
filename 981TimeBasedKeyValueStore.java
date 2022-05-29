//https://leetcode.com/problems/time-based-key-value-store/

class TreeMapSolution {
	TreeMap<String, TreeMap<Integer, String>> treeMap;

	public TreeMapSolution() {
		treeMap = new TreeMap();
	}

	public void set(String key, String value, int timestamp) {
		if (!treeMap.containsKey(key)) {
			treeMap.put(key, new TreeMap<Integer, String> ());
		}
		treeMap.get(key).put(timestamp, value);
	}

	public String get(String key, int timestamp) {
		TreeMap<Integer, String> lst = treeMap.get(key);
		if (lst == null) {
			return "";
		}
		if (lst.containsKey(timestamp)) {
			return lst.get(timestamp);
		}

		Map.Entry<Integer, String> entry = lst.lowerEntry(timestamp);
		return entry == null ? "" : entry.getValue();
	}
}

class BinarySearchSolution {

	Map<String, List<Pair<String, Integer>>> map;

	public BinarySearchSolution() {
		map = new HashMap();
	}

	public void set(String key, String value, int timestamp) {
		if (!map.containsKey(key)) {
			map.put(key, new ArrayList<Pair<String, Integer>> ());
		}
		List lst = map.get(key);
		lst.add(new Pair<>(value, timestamp));
		map.put(key, lst);

	}

	public String get(String key, int timestamp) {
		List<Pair<String, Integer>> lst = map.get(key);
		return lst == null ? "" : binarySearch(lst, timestamp);
	}

	String binarySearch(List<Pair<String, Integer>> lst, int timestamp) {
		int start = 0, end = lst.size() - 1;
		if (lst.get(start).getValue() > timestamp) {
			return "";
		}
		while (start<= end) {
			int mid = start + (end - start) / 2;
			if (lst.get(mid).getValue() == timestamp) {
				return lst.get(mid).getKey();
			}

			if (lst.get(mid).getValue() > timestamp) {
				end = mid - 1;
			} else {
				start = mid + 1;
			}
		}

		return lst.get(end).getKey();
	}
}

class TimeMap {
	TreeMapSolution treeMapSolution;
	BinarySearchSolution binarySearchSolution;
	public TimeMap() {
		treeMapSolution = new TreeMapSolution();
		binarySearchSolution = new BinarySearchSolution();
	}

	public void set(String key, String value, int timestamp) {
		//treeMapSolution.set(key, value, timestamp);
		binarySearchSolution.set(key, value, timestamp);
	}

	public String get(String key, int timestamp) {
		//return treeMapSolution.get(key, timestamp); 
		return binarySearchSolution.get(key, timestamp);
	}
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.set(key,value,timestamp);
 * String param_2 = obj.get(key,timestamp);
 */
