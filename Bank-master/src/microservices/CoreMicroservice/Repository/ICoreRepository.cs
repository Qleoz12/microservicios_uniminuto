using CoreMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMicroservice.Repository
{
    public interface ICoreRepository
    {
        void DeleteAccount(Guid accountId);
        void DeleteCard(Guid cardId);
        void DeleteTransaction(Guid transactionId);
        Account GetAccount(Guid accountId);
        List<Account> GetAccounts();
        Card GetCard(Guid cardid);
        List<Card> GetCards();
        Transaction GetTransaction(Guid transactionId);
        List<Transaction> GetTransactions();
        void InsertAccount(Account account);
        void InsertCard(Card card);
        void InsertTransaction(Transaction transaction);
        void UpdateAccount(Account account);
        void UpdateCard(Card card);
        void UpdateTransaction(Transaction transaction);
    }
}
