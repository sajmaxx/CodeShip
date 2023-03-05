#include <iostream>
#include <future>
#include <chrono>

using namespace std;

// The Stock class represents a stock with a price that changes over time
class Stock {
public:
    Stock(double initialPrice) : mPrice(initialPrice) {}

    // The getPrice function returns the current price of the stock
    double getPrice()
    {
        std::this_thread::sleep_for(std::chrono::milliseconds(100));

        // Simulate some random fluctuations in the price
        mPrice += ((double)rand() / RAND_MAX/2) * 2 + 1;
        return mPrice;
    }

private:
    double mPrice;
};

// The Trader class represents a trader who wants to buy or sell a stock
class Trader {
public:
    Trader() {}

    // The buy function returns a future that represents the result of the trade
    future<double> buy(Stock* stock, double maxPrice) {
        // Create a promise object
        promise<double> myPromise;

        // Get the future object associated with the promise
        future<double> myFuture = myPromise.get_future();

        // Start a new thread to perform the trade
        thread myThread([this, stock, maxPrice, &myPromise]() {
            double price = stock->getPrice();
            if (price <= maxPrice) {
                // The trade was successful
                myPromise.set_value(price);
            } else {
                // The trade failed
                myPromise.set_exception(make_exception_ptr(runtime_error("Price is too high")));
            }
        });

        myThread.join();

        // Return the future object to the caller
        return myFuture;
    }
};


//Add a mediator class between stock and trader class
class Mediator {
public:
    Mediator() {}

    // The buy function returns a future that represents the result of the trade
    future<double> buy(Stock* stock, double maxPrice) {
        // Create a promise object
        promise<double> myPromise;

        // Get the future object associated with the promise
        future<double> myFuture = myPromise.get_future();

        // Start a new thread to perform the trade
        thread myThread([this, stock, maxPrice, &myPromise]() {
            double price = stock->getPrice();
            if (price <= maxPrice) {
                // The trade was successful
                myPromise.set_value(price);
            } else {
                // The trade failed
                myPromise.set_exception(make_exception_ptr(runtime_error("Price is too high")));
            }
        });

        myThread.join();

        // Return the future object to the caller
        return myFuture;
    }
};



int main() {
    // Create a new stock with an initial price of $100
    Stock stock(100);

    // Create a trader
    Trader trader;



    // Wait for the result of the trade
    int i = 0;
    do
    {
        // Buy the stock at a maximum price of $110
        future<double> tradeResult = trader.buy(&stock, 110);
        std::cout << "\nTrying a Trade " << std::endl;
        try
        {
            double price = tradeResult.get();
            cout << "Bought stock for $" << price << endl;
        } catch (const exception& e)
        {
            cout << "Trade failed: " << e.what() << endl;
        }

        std::this_thread::sleep_for(std::chrono::milliseconds(500));
        i++;
    } while (i < 1000);


    //example of using mediator class to buy
    Mediator mediator;
    i = 0;
    do
    {
        // Buy the stock at a maximum price of $110
        future<double> tradeResult = mediator.buy(&stock, 110);
        std::cout << "\nTrying a Trade " << std::endl;
        try
        {
            double price = tradeResult.get();
            cout << "Bought stock for $" << price << endl;
        } catch (const exception& e)
        {
            cout << "Trade failed: " << e.what() << endl;
        }

        std::this_thread::sleep_for(std::chrono::milliseconds(500));
        i++;
    } while (i < 1000);

    return 0;
}
